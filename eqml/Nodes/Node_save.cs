using System.Linq;

namespace Nodes
{
    using System;
    using System.Xml;
    using Attrs;
    using Facade;

    public partial class Node
    {
        public void SavePure(XmlDocument xmlDoc, XmlNode XMLNode, string sXMLEncoding)
        {
            SaveToXml(xmlDoc, XMLNode, sXMLEncoding, null, "");
        }

        public void SaveToXml(
            XmlDocument xmlDoc, XmlNode XMLNode, string sXMLEncoding, Selection Selection_Collection = null)
        {
            SaveToXml(xmlDoc, XMLNode, sXMLEncoding, Selection_Collection, namespaceURI);
        }

        public void SaveToXml(
            XmlDocument xmlDoc, XmlNode XMLNode, string sXMLEncoding, Selection Selection_Collection, string nspace)
        {
            NodesList list;
            XmlNode targetXmlNode = null;
            bool ownSel = false;
            if (Selection_Collection != null && this == Selection_Collection.parent)
            {
                ownSel = true;
                targetXmlNode = XMLNode;
            }

            if (type_ == null)
            {
                return;
            }

            if (!ownSel)
            {
                if (type_.type == ElementType.Entity)
                {
                    targetXmlNode = xmlDoc.CreateNode(XmlNodeType.EntityReference, xmlTagName, nspace);
                }
                else if (!String.IsNullOrEmpty(type_.xmlTag))
                {
                    {
                        targetXmlNode = xmlDoc.CreateNode(XmlNodeType.Element, type_.xmlTag, nspace);

                        if ((type_.type == ElementType.Mtable ||
                             type_.type == ElementType.Mtr ||
                             type_.type == ElementType.Mtd) && attrs != null && attrs.Any())
                        {
                            foreach (var i in attrs)
                            {
                                XmlAttribute attr = xmlDoc.CreateAttribute("", i.name, "");
                                attr.Value = i.val;
                                targetXmlNode.Attributes?.Append(attr);
                            }
                        }
                        if ((type_.type == ElementType.Ms ||
                             type_.type == ElementType.Mtext) && !String.IsNullOrEmpty(literalText))
                        {
                            string s = literalText;
                            if (Selection_Collection != null)
                            {
                                if (Selection_Collection.First != null && Selection_Collection.First == this)
                                {
                                    if (Selection_Collection.Last != null && Selection_Collection.Last == this)
                                    {
                                        s = s.Substring(Selection_Collection.caret,
                                            Selection_Collection.literalLength -
                                            Selection_Collection.caret);
                                    }
                                    else
                                    {
                                        s = s.Substring(Selection_Collection.caret,
                                            s.Length - Selection_Collection.caret);
                                    }
                                }
                                else if (Selection_Collection.Last != null && Selection_Collection.Last == this &&
                                         Selection_Collection.First != this)
                                {
                                    s = s.Substring(0, Selection_Collection.literalLength);
                                }
                            }
                            var selNode = xmlDoc.CreateTextNode(s);
                            targetXmlNode.AppendChild(selNode);
                        }
                        else if (type_.type != ElementType.Mglyph && !String.IsNullOrEmpty(literalText))
                        {
                            string s = literalText;
                            if (Selection_Collection != null)
                            {
                                if (Selection_Collection.First != null && Selection_Collection.First == this)
                                {
                                    if (Selection_Collection.Last != null && Selection_Collection.Last == this)
                                    {
                                        s =
                                            s.Substring(Selection_Collection.caret,
                                                Selection_Collection.literalLength -
                                                Selection_Collection.caret);
                                    }
                                    else
                                    {
                                        s =
                                            s.Substring(Selection_Collection.caret,
                                                s.Length - Selection_Collection.caret);
                                    }
                                }
                                else if (Selection_Collection.Last != null && Selection_Collection.Last == this &&
                                         Selection_Collection.First != this)
                                {
                                    s = s.Substring(0, Selection_Collection.literalLength);
                                }
                            }
                            var selNode = xmlDoc.CreateTextNode(s);
                            targetXmlNode.AppendChild(selNode);
                        }
                    }
                }
            }
            if (targetXmlNode == null)
            {
                return;
            }

            if (XMLNode == null)
            {
                string xml;
                switch (sXMLEncoding)
                {
                    case "UTF-16":
                        xml = "<?xml version='1.0' encoding='UTF-16'?>";
                        break;
                    case "UTF-8":
                        xml = "<?xml version='1.0' encoding='UTF-8'?>";
                        break;
                    default:
                        {
                            xml = sXMLEncoding.Length > 0
                                ? "<?xml version='1.0' encoding='" + sXMLEncoding + "'?>"
                                : "<?xml version='1.0'?>";
                            break;
                        }
                }
                xml += "<root/>";
                xmlDoc.LoadXml(xml);
                if (type_.type == ElementType.Math && displayStyle)
                {
                    XmlAttribute attribute = xmlDoc.CreateAttribute("", "display", "");
                    attribute.Value = "block";
                    targetXmlNode.Attributes?.Append(attribute);
                }

                if (xmlDoc.DocumentElement != null) xmlDoc.ReplaceChild(targetXmlNode, xmlDoc.DocumentElement);
            }
            else if (!ownSel)
            {
                {
                    XMLNode.AppendChild(targetXmlNode);
                }
                if (type_.type == ElementType.Math && displayStyle)
                {
                    XmlAttribute attribute = xmlDoc.CreateAttribute("", "display", "");
                    attribute.Value = "block";
                    targetXmlNode.Attributes?.Append(attribute);
                    XMLNode.AppendChild(targetXmlNode);
                }
            }
            if ((Selection_Collection == null || this != Selection_Collection.parent) && !HasChildren())
            {
                return;
            }
            if (Selection_Collection != null && this == Selection_Collection.parent)
            {
                list = Selection_Collection.nodesList;
            }
            else
            {
                list = GetChildrenNodes();
            }

            list.Reset();
            Node next = list.Next();
            int level = 0;
            XmlNode curXmlNode = targetXmlNode;
            bool ok = true;
            while (next != null && ok)
            {
                var sameSel = false;
                var isPrev = false;
                var isNext = false;

                if (next.type_.type != ElementType.Entity)
                {
                    if (Selection_Collection != null && next == Selection_Collection.First)
                    {
                        if (next.IsSameStyleParent())
                        {
                            sameSel = true;
                        }
                    }
                    else if (next.prevSibling == null)
                    {
                        if (next.IsSameStyleParent())
                        {
                            sameSel = true;
                        }
                    }
                    else if (!next.IsSameStyle(next.prevSibling))
                    {
                        if (next.IsSameStyleParent() && next.prevSibling.IsSameStyleParent())
                        {
                            isNext = true;
                        }
                        else
                        {
                            if (next.prevSibling.IsSameStyleParent())
                            {
                                isPrev = true;
                            }
                            if (next.IsSameStyleParent())
                            {
                                sameSel = true;
                            }
                        }
                    }
                }
                if (isNext)
                {
                    if (next.prevSibling.IsSameStyleParent() && level > 0)
                    {
                        curXmlNode = curXmlNode.ParentNode;
                        level--;
                    }
                    sameSel = true;
                }
                if (sameSel && next.IsSameStyleParent())
                {
                    Node snode;
                    if (next.style_ is null) next.style_ = new StyleAttributes();

                    snode = next.parent_?.style_ != null
                        ? new Node(next.parent_.style_)
                        : new Node(new StyleAttributes());
                    var mstyleNode = xmlDoc.CreateNode(XmlNodeType.Element, "mstyle", nspace);
                    AttributeBuilder.CascadeStyles(next.parent_, snode, next.style_);
                    if (snode.attrs != null)
                    {
                        foreach (var i in snode.attrs)
                        {
                            XmlAttribute attr = xmlDoc.CreateAttribute("", i.name, "");
                            attr.Value = i.val;
                            mstyleNode.Attributes.Append(attr);
                        }
                    }
                    curXmlNode.AppendChild(mstyleNode);
                    curXmlNode = mstyleNode;
                    level++;
                }
                if (isPrev && next.prevSibling.IsSameStyleParent())
                {
                    curXmlNode = curXmlNode.ParentNode;
                    level--;
                }

                next.SaveToXml(xmlDoc, curXmlNode, sXMLEncoding, Selection_Collection, nspace);
                next = list.Next();
                if (Selection_Collection?.Last != null && next == Selection_Collection.Last &&
                    Selection_Collection.literalLength == 0)
                {
                    ok = false;
                }
            }
        }
    }
}