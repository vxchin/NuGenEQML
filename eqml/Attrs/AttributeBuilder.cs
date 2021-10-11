namespace Attrs
{
    using System;
    using System.Drawing;
    using System.Globalization;
    using Nodes;

    public static class AttributeBuilder
    {
        public static void ApplyAttrs(Node node, TableCellAttributes tableCellAttributes)
        {
            if (node?.type_ != null && node.type_.type == ElementType.Mtd && tableCellAttributes != null)
            {
                switch (tableCellAttributes.rowAlign)
                {
                    case RowAlign.TOP:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "top");
                            break;
                        }
                    case RowAlign.BOTTOM:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "bottom");
                            break;
                        }
                    case RowAlign.CENTER:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "center");
                            break;
                        }
                    case RowAlign.BASELINE:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "baseline");
                            break;
                        }
                    case RowAlign.AXIS:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "axis");
                            break;
                        }
                    case RowAlign.UNKNOWN when node.attrs != null:
                        {
                            Nodes.Attribute attribute = node.attrs.Get("rowalign");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                            break;
                        }
                }
                switch (tableCellAttributes.columnAlign)
                {
                    case HAlign.LEFT:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("columnalign", "left");
                            break;
                        }
                    case HAlign.CENTER:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("columnalign", "center");
                            break;
                        }
                    case HAlign.RIGHT:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("columnalign", "right");
                            break;
                        }
                    case HAlign.UNKNOWN when node.attrs != null:
                        {
                            Nodes.Attribute attribute = node.attrs.Get("columnalign");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                            break;
                        }
                }
                if (tableCellAttributes.rowSpan != 1)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    string s = tableCellAttributes.rowSpan.ToString();
                    if (s.Length > 0)
                    {
                        node.attrs.Add("rowspan", s);
                    }
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("rowspan");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
                if (tableCellAttributes.columnSpan != 1)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    string s = tableCellAttributes.columnSpan.ToString();
                    if (s.Length > 0)
                    {
                        node.attrs.Add("columnspan", s);
                    }
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("columnspan");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
            }
        }

        public static FencedAttributes FencedAttrsFromNode(Node node)
        {
            Nodes.Attribute attribute = null;
            FencedAttributes attributes = null;
            try
            {
                if (node.attrs == null)
                {
                    return attributes;
                }
                node.attrs.Reset();
                for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                {
                    string s = attribute.val.Trim();
                    if (attributes == null)
                    {
                        attributes = new FencedAttributes();
                    }
                    switch (attribute.name)
                    {
                        case "open" when s.Length > 0:
                            attributes.open = s;
                            break;
                        case "open":
                            attributes.open = "NONE";
                            break;
                        case "close" when s.Length > 0:
                            attributes.close = s;
                            break;
                        case "close":
                            attributes.close = "NONE";
                            break;
                        case "separators" when s.Length > 0:
                            attributes.separators = s;
                            break;
                        case "separators":
                            attributes.separators = "NONE";
                            break;
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
            return attributes;
        }

        public static void ApplyAttrs(Node node, FencedAttributes fencedAttributes)
        {
            if (node?.type_ != null && node.type_.type == ElementType.Mfenced && fencedAttributes != null)
            {
                if (fencedAttributes.separators.Length > 0)
                {
                    if (fencedAttributes.separators == ",")
                    {
                        if (node.attrs != null)
                        {
                            Nodes.Attribute attribute = node.attrs.Get("separators");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                        }
                    }
                    else
                    {
                        if (node.attrs == null)
                        {
                            node.attrs = new AttributeList();
                        }
                        if (fencedAttributes.separators == "NONE")
                        {
                            node.attrs.Add("separators", "");
                        }
                        else
                        {
                            node.attrs.Add("separators", fencedAttributes.separators);
                        }
                    }
                }
                if (fencedAttributes.open.Length > 0)
                {
                    if (fencedAttributes.open == "{" || fencedAttributes.open == "[" || fencedAttributes.open == "|" || fencedAttributes.open == "<" || fencedAttributes.open[0] == '\u2329' || fencedAttributes.open[0] == '<')
                    {
                        if (node.attrs == null)
                        {
                            node.attrs = new AttributeList();
                        }
                        node.attrs.Add("open", fencedAttributes.open);
                    }
                    else switch (fencedAttributes.open)
                        {
                            case "NONE":
                                {
                                    if (node.attrs == null)
                                    {
                                        node.attrs = new AttributeList();
                                    }
                                    node.attrs.Add("open", "");
                                    break;
                                }
                            case "(" when node.attrs != null:
                                {
                                    Nodes.Attribute attribute = node.attrs.Get("open");
                                    if (attribute != null)
                                    {
                                        node.attrs.Remove(attribute);
                                    }
                                    break;
                                }
                        }
                }
                if (fencedAttributes.close.Length > 0)
                {
                    if (fencedAttributes.close == "}" || fencedAttributes.close == "]" || fencedAttributes.close == "|" || fencedAttributes.close == ">" || fencedAttributes.close[0] == '\u232a' || fencedAttributes.close[0] == '>')
                    {
                        if (node.attrs == null)
                        {
                            node.attrs = new AttributeList();
                        }
                        node.attrs.Add("close", fencedAttributes.close);
                    }
                    else switch (fencedAttributes.close)
                        {
                            case "NONE":
                                {
                                    if (node.attrs == null)
                                    {
                                        node.attrs = new AttributeList();
                                    }
                                    node.attrs.Add("close", "");
                                    break;
                                }
                            case ")" when node.attrs != null:
                                {
                                    Nodes.Attribute attribute = node.attrs.Get("close");
                                    if (attribute != null)
                                    {
                                        node.attrs.Remove(attribute);
                                    }
                                    break;
                                }
                        }
                }
            }
        }

        public static FractionAttributes FractionAttrsFromNode(Node node)
        {
            Nodes.Attribute attribute = null;
            FractionAttributes fractionAttributes = null;
            try
            {
                if (node.attrs == null)
                {
                    return fractionAttributes;
                }
                node.attrs.Reset();
                for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                {
                    string s = attribute.val.Trim();
                    switch (attribute.name)
                    {
                        case "linethickness":
                            {
                                if (s.Length > 0)
                                {
                                    int lineThickness = 1;
                                    switch (s.ToUpper())
                                    {
                                        case "THIN":
                                            lineThickness = 1;
                                            break;
                                        case "MEDIUM":
                                            lineThickness = 2;
                                            break;
                                        case "THICK":
                                            lineThickness = 3;
                                            break;
                                        default:
                                            {
                                                bool isInteger = true;
                                                for (int i = 0; i < s.Length; i++)
                                                {
                                                    if (s[i] == '.')
                                                    {
                                                        isInteger = false;
                                                    }
                                                }
                                                if (isInteger)
                                                {
                                                    try
                                                    {
                                                        lineThickness = Convert.ToInt32(s);
                                                    }
                                                    catch
                                                    {
                                                        lineThickness = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    lineThickness = 1;
                                                }
                                                break;
                                            }
                                    }
                                    if (fractionAttributes == null)
                                    {
                                        fractionAttributes = new FractionAttributes();
                                    }
                                    fractionAttributes.lineThickness = lineThickness;
                                }
                                break;
                            }
                        case "numalign":
                            {
                                if (s.Length > 0)
                                {
                                    if (fractionAttributes == null)
                                    {
                                        fractionAttributes = new FractionAttributes();
                                    }
                                    switch (s.ToUpper())
                                    {
                                        case "LEFT":
                                            fractionAttributes.numAlign = FractionAlign.LEFT;
                                            break;
                                        case "CENTER":
                                            fractionAttributes.numAlign = FractionAlign.CENTER;
                                            break;
                                        case "RIGHT":
                                            fractionAttributes.numAlign = FractionAlign.RIGHT;
                                            break;
                                    }
                                }
                                break;
                            }
                        case "denomalign":
                            {
                                if (s.Length > 0)
                                {
                                    if (fractionAttributes == null)
                                    {
                                        fractionAttributes = new FractionAttributes();
                                    }
                                    switch (s.ToUpper())
                                    {
                                        case "LEFT":
                                            fractionAttributes.denomAlign = FractionAlign.LEFT;
                                            break;
                                        case "CENTER":
                                            fractionAttributes.denomAlign = FractionAlign.CENTER;
                                            break;
                                        case "RIGHT":
                                            fractionAttributes.denomAlign = FractionAlign.RIGHT;
                                            break;
                                    }
                                }
                                break;
                            }
                        case "bevelled" when s.Length > 0:
                            {
                                if (fractionAttributes == null)
                                {
                                    fractionAttributes = new FractionAttributes();
                                }
                                fractionAttributes.isBevelled = s.ToUpper() == "TRUE";
                                break;
                            }
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
            return fractionAttributes;
        }

        public static FractionAttributes FractionAttrsFromNode(float emHeight, float DPI, Node node)
        {
            Nodes.Attribute attribute = null;
            FractionAttributes attributes = null;
            try
            {
                if (node.attrs == null)
                {
                    return attributes;
                }
                node.attrs.Reset();
                for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                {
                    string s = attribute.val.Trim();
                    switch (attribute.name)
                    {
                        case "linethickness":
                            {
                                if (s.Length > 0)
                                {
                                    int lineThickness = 1;
                                    switch (s.ToUpper())
                                    {
                                        case "THIN":
                                            lineThickness = 1;
                                            break;
                                        case "MEDIUM":
                                            lineThickness = 2;
                                            break;
                                        case "THICK":
                                            lineThickness = 3;
                                            break;
                                        default:
                                            {
                                                bool isInteger = true;
                                                for (int i = 0; i < s.Length; i++)
                                                {
                                                    if (s[i] == '.')
                                                    {
                                                        isInteger = false;
                                                    }
                                                }
                                                if (isInteger)
                                                {
                                                    try
                                                    {
                                                        lineThickness = Convert.ToInt32(s);
                                                    }
                                                    catch
                                                    {
                                                        try
                                                        {
                                                            if (!char.IsLetter(s[s.Length - 1]))
                                                            {
                                                                s = s + "ex";
                                                            }
                                                            lineThickness = AttributeBuilder.FontWidth(emHeight, DPI, s, 1);
                                                        }
                                                        catch
                                                        {
                                                            lineThickness = 1;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        if (!char.IsLetter(s[s.Length - 1]))
                                                        {
                                                            s = s + "ex";
                                                        }
                                                        lineThickness = AttributeBuilder.FontWidth(emHeight, DPI, s, 1);
                                                    }
                                                    catch
                                                    {
                                                        lineThickness = 1;
                                                    }
                                                }
                                                break;
                                            }
                                    }
                                    if (attributes == null)
                                    {
                                        attributes = new FractionAttributes();
                                    }
                                    attributes.lineThickness = lineThickness;
                                }
                                break;
                            }
                        case "numalign":
                            {
                                if (s.Length > 0)
                                {
                                    if (attributes == null)
                                    {
                                        attributes = new FractionAttributes();
                                    }
                                    switch (s.ToUpper())
                                    {
                                        case "LEFT":
                                            attributes.numAlign = FractionAlign.LEFT;
                                            break;
                                        case "CENTER":
                                            attributes.numAlign = FractionAlign.CENTER;
                                            break;
                                        case "RIGHT":
                                            attributes.numAlign = FractionAlign.RIGHT;
                                            break;
                                    }
                                }
                                break;
                            }
                        case "denomalign":
                            {
                                if (s.Length > 0)
                                {
                                    if (attributes == null)
                                    {
                                        attributes = new FractionAttributes();
                                    }
                                    switch (s.ToUpper())
                                    {
                                        case "LEFT":
                                            attributes.denomAlign = FractionAlign.LEFT;
                                            break;
                                        case "CENTER":
                                            attributes.denomAlign = FractionAlign.CENTER;
                                            break;
                                        case "RIGHT":
                                            attributes.denomAlign = FractionAlign.RIGHT;
                                            break;
                                    }
                                }
                                break;
                            }
                        case "bevelled" when s.Length > 0:
                            {
                                if (attributes == null)
                                {
                                    attributes = new FractionAttributes();
                                }
                                attributes.isBevelled = s.ToUpper() == "TRUE";
                                break;
                            }
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
            return attributes;
        }

        public static void ApplyAttrs(Node node, FractionAttributes fractionAttributes)
        {
            if (node?.type_ != null && node.type_.type == ElementType.Mfrac && fractionAttributes != null)
            {
                if (fractionAttributes.isBevelled)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    node.attrs.Add("bevelled", "true");
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("bevelled");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
                if (fractionAttributes.lineThickness != 1)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    node.attrs.Add("linethickness", fractionAttributes.lineThickness.ToString());
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("linethickness");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
                if (fractionAttributes.denomAlign != FractionAlign.CENTER)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    switch (fractionAttributes.denomAlign)
                    {
                        case FractionAlign.LEFT:
                            node.attrs.Add("denomalign", "left");
                            break;
                        case FractionAlign.RIGHT:
                            node.attrs.Add("denomalign", "right");
                            break;
                        default:
                            node.attrs.Add("denomalign", "center");
                            break;
                    }
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("denomalign");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
                if (fractionAttributes.numAlign != FractionAlign.CENTER)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    switch (fractionAttributes.numAlign)
                    {
                        case FractionAlign.LEFT:
                            node.attrs.Add("numalign", "left");
                            break;
                        case FractionAlign.RIGHT:
                            node.attrs.Add("numalign", "right");
                            break;
                        default:
                            node.attrs.Add("numalign", "center");
                            break;
                    }
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("numalign");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
            }
        }

        public static ActionAttributes ActionAttributes(Node node)
        {
            Nodes.Attribute attribute = null;
            ActionAttributes attributes = null;
            try
            {
                if (node.attrs == null)
                {
                    return attributes;
                }
                node.attrs.Reset();
                for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                {
                    string s = attribute.val.Trim();
                    switch (attribute.name)
                    {
                        case "actiontype":
                            {
                                if (s.Length > 0)
                                {
                                    ActionType actionType = ActionType.StatusLine;
                                    switch (s.ToUpper())
                                    {
                                        case "STATUSLINE":
                                            actionType = ActionType.StatusLine;
                                            break;
                                        case "TOOLTIP":
                                            actionType = ActionType.ToolTip;
                                            break;
                                        case "HIGHLIGHT":
                                            actionType = ActionType.Highlight;
                                            break;
                                        case "TOGGLE":
                                            actionType = ActionType.Toggle;
                                            break;
                                        default:
                                            actionType = ActionType.Unknown;
                                            break;
                                    }
                                    if (attributes == null)
                                    {
                                        attributes = new ActionAttributes();
                                    }
                                    attributes.actionType = actionType;
                                    attributes.actionString = s;
                                }
                                break;
                            }
                        case "selection" when s.Length > 0:
                            {
                                if (attributes == null)
                                {
                                    attributes = new ActionAttributes();
                                }
                                attributes.selection = Convert.ToInt32(s.Trim());
                                break;
                            }
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
            return attributes;
        }

        public static StyleAttributes StyleAttrsFromNode(Node node)
        {
            return AttributeBuilder.StyleAttrsFromNode(node, false);
        }

        public static StyleAttributes StyleAttrsFromNode(Node node, bool bMStyle)
        {
            Nodes.Attribute attribute = null;
            StyleAttributes attributes = null;
            try
            {
                if (node.attrs == null)
                {
                    return attributes;
                }
                node.attrs.Reset();
                for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                {
                    string s = attribute.val.Trim();
                    switch (bMStyle)
                    {
                        case true when attribute.name == "displaystyle":
                            {
                                switch (s.ToUpper())
                                {
                                    case "TRUE":
                                        {
                                            if (attributes == null)
                                            {
                                                attributes = new StyleAttributes();
                                            }
                                            attributes.displayStyle = DisplayStyle.TRUE;
                                            break;
                                        }
                                    case "FALSE":
                                        {
                                            if (attributes == null)
                                            {
                                                attributes = new StyleAttributes();
                                            }
                                            attributes.displayStyle = DisplayStyle.FALSE;
                                            break;
                                        }
                                }
                                break;
                            }
                        case true when attribute.name == "scriptlevel":
                            {
                                s = s.Trim();
                                string levelStr = "";
                                int level = 0;
                                bool plus = false;
                                bool minus = false;
                                switch (s.Length > 0)
                                {
                                    case true when s[0] == '+':
                                        plus = true;
                                        levelStr = s.Substring(1, s.Length - 1);
                                        break;
                                    case true when s[0] == '-':
                                        minus = true;
                                        levelStr = s.Substring(1, s.Length - 1);
                                        break;
                                    default:
                                        levelStr = s;
                                        break;
                                }
                                try
                                {
                                    level = Convert.ToInt32(levelStr);
                                    if (level > 2)
                                    {
                                        level = 2;
                                    }
                                    if (level < 0)
                                    {
                                        level = 0;
                                    }
                                }
                                catch
                                {
                                    level = 0;
                                }
                                switch (plus)
                                {
                                    case true when level == 1:
                                        {
                                            if (attributes == null)
                                            {
                                                attributes = new StyleAttributes();
                                            }
                                            attributes.scriptLevel = ScriptLevel.PLUS_ONE;
                                            break;
                                        }
                                    case true when level == 2:
                                        {
                                            if (attributes == null)
                                            {
                                                attributes = new StyleAttributes();
                                            }
                                            attributes.scriptLevel = ScriptLevel.PLUS_TWO;
                                            break;
                                        }
                                    default:
                                        {
                                            switch (minus)
                                            {
                                                case true when level == 1:
                                                    {
                                                        if (attributes == null)
                                                        {
                                                            attributes = new StyleAttributes();
                                                        }
                                                        attributes.scriptLevel = ScriptLevel.MINUS_TWO;
                                                        break;
                                                    }
                                                case true when level == 2:
                                                    {
                                                        if (attributes == null)
                                                        {
                                                            attributes = new StyleAttributes();
                                                        }
                                                        attributes.scriptLevel = ScriptLevel.MINUS_TWO;
                                                        break;
                                                    }
                                                default:
                                                    {
                                                        switch (plus)
                                                        {
                                                            case false when !minus && level == 0:
                                                                {
                                                                    if (attributes == null)
                                                                    {
                                                                        attributes = new StyleAttributes();
                                                                    }
                                                                    attributes.scriptLevel = ScriptLevel.ZERO;
                                                                    break;
                                                                }
                                                            case false when !minus && level == 1:
                                                                {
                                                                    if (attributes == null)
                                                                    {
                                                                        attributes = new StyleAttributes();
                                                                    }
                                                                    attributes.scriptLevel = ScriptLevel.ONE;
                                                                    break;
                                                                }
                                                            case false when !minus && level == 2:
                                                                {
                                                                    if (attributes == null)
                                                                    {
                                                                        attributes = new StyleAttributes();
                                                                    }
                                                                    attributes.scriptLevel = ScriptLevel.TWO;
                                                                    break;
                                                                }
                                                        }
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                        default:
                            {
                                switch (attribute.name)
                                {
                                    case "mathvariant":
                                        {
                                            if (s.Length > 0)
                                            {
                                                if (attributes == null)
                                                {
                                                    attributes = new StyleAttributes();
                                                }
                                                switch (s)
                                                {
                                                    case "fraktur":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = true;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "bold":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = true;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "bold-italic":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = true;
                                                        attributes.isItalic = true;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "bold-fraktur":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = true;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = true;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "bold-script":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = true;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = true;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "bold-sans-serif":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = true;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = true;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "italic":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = true;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "sans-serif-italic":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = true;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = true;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "sans-serif-bold-italic":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = true;
                                                        attributes.isItalic = true;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = true;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "double-struck":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = true;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "monospace":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = true;
                                                        break;
                                                    case "script":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = true;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "sans-serif":
                                                        attributes.isNormal = false;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = true;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    case "normal":
                                                        attributes.isNormal = true;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                    default:
                                                        attributes.isNormal = false;
                                                        attributes.isBold = false;
                                                        attributes.isItalic = false;
                                                        attributes.isFractur = false;
                                                        attributes.isSans = false;
                                                        attributes.isDoubleStruck = false;
                                                        attributes.isScript = false;
                                                        attributes.isMonospace = false;
                                                        break;
                                                }
                                            }
                                            break;
                                        }
                                    case "mathcolor":
                                        {
                                            if (s.Length > 0)
                                            {
                                                if (attributes == null)
                                                {
                                                    attributes = new StyleAttributes();
                                                }
                                                attributes.color = ColorTranslator.FromHtml(s);
                                            }
                                            attributes.hasColor = true;
                                            break;
                                        }
                                    case "mathbackground":
                                        {
                                            if (s.Length > 0)
                                            {
                                                if (attributes == null)
                                                {
                                                    attributes = new StyleAttributes();
                                                }
                                                attributes.background = ColorTranslator.FromHtml(s);
                                            }
                                            attributes.hasBackground = true;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    if (attribute.name == "mathsize" && s.Length > 0)
                    {
                        if (attributes == null)
                        {
                            attributes = new StyleAttributes();
                        }
                        attributes.size = s;
                        attributes.hasSize = true;
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
            return attributes;
        }

        public static void CascadeStyles(Node parentNode, Node node, StyleAttributes styleAttributes)
        {
            string fontSize;
            string mathSize;
            if (node == null || styleAttributes == null)
            {
                return;
            }

            if (node.style_ == null)
            {
                string font = styleAttributes.FontToString();
                if (font == "")
                {
                    if (node.attrs != null)
                    {
                        Nodes.Attribute attribute = node.attrs.Get("mathvariant");
                        if (attribute != null)
                        {
                            node.attrs.Remove(attribute);
                        }
                    }
                }
                else
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    if (font.Length > 0)
                    {
                        node.attrs.Add("mathvariant", font);
                    }
                }

                if (styleAttributes.displayStyle == DisplayStyle.AUTOMATIC)
                {
                    if (node.attrs != null)
                    {
                        Nodes.Attribute attribute = node.attrs.Get("displaystyle");
                        if (attribute != null)
                        {
                            node.attrs.Remove(attribute);
                        }
                    }
                }
                else
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }

                    switch (styleAttributes.displayStyle)
                    {
                        case DisplayStyle.TRUE:
                            {
                                node.attrs.Add("displaystyle", "true");
                                break;
                            }
                        case DisplayStyle.FALSE:
                            {
                                node.attrs.Add("displaystyle", "false");
                                break;
                            }
                    }
                }
            }
            else
            {
                string fontToString = "";
                string styleFont = "";
                fontToString = styleAttributes.FontToString();
                styleFont = node.style_.FontToString();
                if (fontToString.Length > 0 && fontToString != styleFont)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    node.attrs.Add("mathvariant", fontToString);
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("mathvariant");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }

                bool topLevel = false;
                bool hasDisplayStyle = false;
                if (parentNode?.type_ != null && parentNode.type_.type == ElementType.Math)
                {
                    topLevel = true;
                }
                DisplayStyle displayStyle = styleAttributes.displayStyle;
                DisplayStyle styleDisplayStyle = node.style_.displayStyle;
                if (topLevel && parentNode != null &&
                    (displayStyle == DisplayStyle.TRUE && parentNode.displayStyle ||
                     displayStyle == DisplayStyle.FALSE && !parentNode.displayStyle))
                {
                    hasDisplayStyle = true;
                }
                if (displayStyle != styleDisplayStyle && displayStyle != DisplayStyle.AUTOMATIC &&
                    !hasDisplayStyle)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    switch (displayStyle)
                    {
                        case DisplayStyle.TRUE:
                            {
                                node.attrs.Add("displaystyle", "true");
                                break;
                            }
                        case DisplayStyle.FALSE:
                            {
                                node.attrs.Add("displaystyle", "false");
                                break;
                            }
                    }
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("displaystyle");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }

                hasDisplayStyle = false;
                ScriptLevel scriptLevel = styleAttributes.scriptLevel;
                ScriptLevel styleScriptLevel = node.style_.scriptLevel;
                if (topLevel && parentNode != null &&
                    (scriptLevel == ScriptLevel.ZERO && parentNode.scriptLevel_ == 0 ||
                     scriptLevel == ScriptLevel.ONE && parentNode.scriptLevel_ == 1 ||
                     scriptLevel == ScriptLevel.TWO && parentNode.scriptLevel_ == 2))
                {
                    hasDisplayStyle = true;
                }
                if (scriptLevel != styleScriptLevel && scriptLevel != ScriptLevel.NONE && !hasDisplayStyle)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    switch (scriptLevel)
                    {
                        case ScriptLevel.ZERO:
                            {
                                node.attrs.Add("scriptlevel", "0");
                                break;
                            }
                        case ScriptLevel.ONE:
                            {
                                node.attrs.Add("scriptlevel", "1");
                                break;
                            }
                        case ScriptLevel.TWO:
                            {
                                node.attrs.Add("scriptlevel", "2");
                                break;
                            }
                        case ScriptLevel.PLUS_ONE:
                            {
                                node.attrs.Add("scriptlevel", "+1");
                                break;
                            }
                        case ScriptLevel.PLUS_TWO:
                            {
                                node.attrs.Add("scriptlevel", "+2");
                                break;
                            }
                        case ScriptLevel.MINUS_ONE:
                            {
                                node.attrs.Add("scriptlevel", "-1");
                                break;
                            }
                        case ScriptLevel.MINUS_TWO:
                            {
                                node.attrs.Add("scriptlevel", "-2");
                                break;
                            }
                    }
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("scriptlevel");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }

                fontSize = "";
                string ownFontSize = "";
                fontSize = styleAttributes.FontSize();
                ownFontSize = node.style_.FontSize();
                if (fontSize != ownFontSize)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    if (fontSize.Length > 0)
                    {
                        node.attrs.Add("mathsize", fontSize);
                    }
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("mathsize");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
                if (styleAttributes.color != node.style_.color)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    node.attrs.Add("mathcolor", ColorTranslator.ToHtml(styleAttributes.color));
                }
                else if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("mathcolor");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
                if (styleAttributes.background != node.style_.background)
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    node.attrs.Add("mathbackground", ColorTranslator.ToHtml(styleAttributes.background));
                    return;
                }
                if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("mathbackground");
                    if (attribute == null)
                    {
                        return;
                    }
                    node.attrs.Remove(attribute);
                }
                return;
            }

            if (styleAttributes.scriptLevel == ScriptLevel.NONE)
            {
                if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("scriptlevel");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
            }
            else
            {
                if (node.attrs == null)
                {
                    node.attrs = new AttributeList();
                }
                switch (styleAttributes.scriptLevel)
                {
                    case ScriptLevel.ZERO:
                        {
                            node.attrs.Add("scriptlevel", "0");
                            break;
                        }
                    case ScriptLevel.ONE:
                        {
                            node.attrs.Add("scriptlevel", "1");
                            break;
                        }
                    case ScriptLevel.TWO:
                        {
                            node.attrs.Add("scriptlevel", "2");
                            break;
                        }
                    case ScriptLevel.PLUS_ONE:
                        {
                            node.attrs.Add("scriptlevel", "+1");
                            break;
                        }
                    case ScriptLevel.PLUS_TWO:
                        {
                            node.attrs.Add("scriptlevel", "+2");
                            break;
                        }
                    case ScriptLevel.MINUS_ONE:
                        {
                            node.attrs.Add("scriptlevel", "-1");
                            break;
                        }
                    case ScriptLevel.MINUS_TWO:
                        {
                            node.attrs.Add("scriptlevel", "-2");
                            break;
                        }
                }
            }

            mathSize = "";
            mathSize = styleAttributes.FontSize();
            if (mathSize == "normal")
            {
                if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("mathsize");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
            }
            else
            {
                if (node.attrs == null)
                {
                    node.attrs = new AttributeList();
                }
                if (mathSize.Length > 0)
                {
                    node.attrs.Add("mathsize", mathSize);
                }
            }
            if (styleAttributes.color == Color.Black)
            {
                if (node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("mathcolor");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
            }
            else
            {
                if (node.attrs == null)
                {
                    node.attrs = new AttributeList();
                }
                node.attrs.Add("mathcolor", ColorTranslator.ToHtml(styleAttributes.color));
            }
            if (styleAttributes.background == Color.White)
            {
                if (node.attrs == null)
                {
                    return;
                }
                Nodes.Attribute attribute = node.attrs.Get("mathbackground");
                if (attribute == null)
                {
                    return;
                }
                node.attrs.Remove(attribute);
            }
            else
            {
                if (node.attrs == null)
                {
                    node.attrs = new AttributeList();
                }
                node.attrs.Add("mathbackground", ColorTranslator.ToHtml(styleAttributes.background));
            }
        }

        public static void ApplyMglyphAttrs(Node node)
        {
            Nodes.Attribute attribute = null;
            try
            {
                if (node.attrs == null)
                {
                    return;
                }

                node.attrs.Reset();
                for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                {
                    string attrval = attribute.val.Trim();
                    switch (attribute.name)
                    {
                        case "fontfamily":
                            {
                                if (attrval.Length > 0)
                                {
                                    node.fontFamily = attrval;
                                }
                                break;
                            }
                        case "index" when attrval.Length > 0:
                            node.literalText = "" + (char)(ushort)Convert.ToInt32(attrval);
                            break;
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
        }

        public static QuoteAttributes QuoteAttributes(Node node)
        {
            Nodes.Attribute attribute = null;
            QuoteAttributes quoteAttributes = null;
            try
            {
                if (node.attrs == null)
                {
                    return quoteAttributes;
                }
                node.attrs.Reset();
                for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                {
                    string s = attribute.val.Trim();
                    if (quoteAttributes == null)
                    {
                        quoteAttributes = new QuoteAttributes();
                    }
                    switch (attribute.name)
                    {
                        case "lquote" when s.Length > 0:
                            quoteAttributes.lquote = s;
                            break;
                        case "lquote":
                            quoteAttributes.lquote = "NONE";
                            break;
                        case "rquote" when s.Length > 0:
                            quoteAttributes.rquote = s;
                            break;
                        case "rquote":
                            quoteAttributes.rquote = "NONE";
                            break;
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
            return quoteAttributes;
        }

        public static int FontWidth(float emHeight, float DPI, string s, double dDefault)
        {
            int length = 0;
            bool hasThickness = false;
            bool hasEms = false;
            bool hasEx = false;
            bool hasPx = false;
            bool hasUnits = false;
            bool hasPercents = false;
            bool isInfinity = false;
            double scale = 0;
            double thickScale = 1;
            string suffix = "";
            string sAmount = "";
            double amount = 0;
            double val = 2;

            try
            {
                string thickStr;
                s = s.Trim();
                length = s.Length;
                if (length < 2)
                {
                    return (int)Math.Round(val, 0);
                }

                suffix = "";
                suffix = suffix + s[length - 2];
                suffix = suffix + s[length - 1];

                bool gotThickness = false;
                if ((thickStr = s) != null)
                {
                    switch (thickStr)
                    {
                        case "infinity":
                            isInfinity = true;
                            gotThickness = true;
                            break;
                        case "veryverythinmathspace":
                            thickScale = 0.055555600672960281;
                            hasEms = true;
                            gotThickness = true;
                            break;
                        case "verythinmathspace":
                            thickScale = 0.11111100018024445;
                            hasThickness = true;
                            gotThickness = true;
                            break;
                        case "thinmathspace":
                            thickScale = 0.16666699945926666;
                            hasThickness = true;
                            gotThickness = true;
                            break;
                        case "mediummathspace":
                            thickScale = 0.22222200036048889;
                            hasThickness = true;
                            gotThickness = true;
                            break;
                        case "thickmathspace":
                            thickScale = 0.27777799963951111;
                            hasThickness = true;
                            gotThickness = true;
                            break;
                        case "verythickmathspace":
                            thickScale = 0.33333298563957214;
                            hasThickness = true;
                            gotThickness = true;
                            break;
                        case "veryverythickmathspace":
                            thickScale = 0.38888901472091675;
                            hasThickness = true;
                            gotThickness = true;
                            break;
                    }
                }

                if (!gotThickness)
                {
                    if ((thickStr = suffix) != null)
                    {
                        switch (thickStr)
                        {
                            case "em":
                                sAmount = s.Substring(0, length - 2);
                                hasEms = true;
                                break;
                            case "ex":
                                sAmount = s.Substring(0, length - 2);
                                hasEx = true;
                                break;
                            case "px":
                                sAmount = s.Substring(0, length - 2);
                                hasPx = true;
                                break;
                            case "in":
                                sAmount = s.Substring(0, length - 2);
                                scale = 25.4;
                                hasUnits = true;
                                break;
                            case "cm":
                                sAmount = s.Substring(0, length - 2);
                                scale = 10;
                                hasUnits = true;
                                break;
                            case "mm":
                                sAmount = s.Substring(0, length - 2);
                                scale = 1;
                                hasUnits = true;
                                break;
                            case "pt":
                                sAmount = s.Substring(0, length - 2);
                                scale = 0.352777777777552;
                                hasUnits = true;
                                break;
                            case "pc":
                                sAmount = s.Substring(0, length - 2);
                                scale = 4.2333333333306236;
                                hasUnits = true;
                                break;
                            default:
                                {
                                    if (s[length] == '%')
                                    {
                                        sAmount = s.Substring(0, length - 1);
                                        hasPercents = true;
                                    }
                                    else
                                    {
                                        sAmount = s;
                                        hasPx = true;
                                    }
                                    break;
                                }
                        }
                    }
                    else
                    {
                        if (s[length] == '%')
                        {
                            sAmount = s.Substring(0, length - 1);
                            hasPercents = true;
                        }
                        else
                        {
                            sAmount = s;
                            hasPx = true;
                        }
                    }
                }

                sAmount = sAmount.Trim();
                if (sAmount.Length > 0)
                {
                    if (sAmount[0] == '.')
                    {
                        sAmount = "0" + sAmount;
                    }
                    else if (sAmount.Length > 1 && sAmount[0] == '-' && sAmount[1] == '.')
                    {
                        sAmount = "-0" + sAmount.Substring(1, sAmount.Length - 2);
                    }
                    sAmount = sAmount.Replace(".", NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                    try
                    {
                        amount = Convert.ToDouble(sAmount);
                    }
                    catch
                    {
                    }
                }
                else
                {
                    amount = 0;
                }

                if (hasThickness)
                {
                    val = thickScale * emHeight;
                }
                else if (hasPercents)
                {
                    val = dDefault * amount * 0.01;
                }
                else if (hasPx)
                {
                    val = amount;
                }
                else if (hasUnits)
                {
                    val = amount * scale * ((double)DPI / 25.4);
                }
                else if (hasEms)
                {
                    val = amount * emHeight;
                }
                else if (hasEx)
                {
                    val = amount * emHeight * 0.5;
                }
                else if (isInfinity)
                {
                    val = 100000;
                }

                return (int)Math.Round(val, 0);
            }
            catch
            {
                return (int)Math.Round(dDefault, 0);
            }
        }

        public static int SizeByAttr(float emHeight, float DPI, Node node, string attrName, double dDefault)
        {
            try
            {
                if (node.attrs != null)
                {
                    string s = node.attrs.GetValue(attrName);
                    if (s != null && s.Length > 0)
                    {
                        return AttributeBuilder.FontWidth(emHeight, DPI, s, dDefault);
                    }
                    return (int)dDefault;
                }
                return (int)dDefault;
            }
            catch
            {
                return (int)dDefault;
            }
        }

        public static void ApplyAttrs(Node node, ActionAttributes actionAttributes)
        {
            if (node?.type_ != null && node.type_.type == ElementType.Maction && actionAttributes != null)
            {
                if (node.attrs == null)
                {
                    node.attrs = new AttributeList();
                }
                switch (actionAttributes.actionType)
                {
                    case ActionType.StatusLine:
                        node.attrs.Add("actiontype", "statusline");
                        break;
                    case ActionType.Toggle:
                        node.attrs.Add("actiontype", "toggle");
                        break;
                    case ActionType.Highlight:
                        node.attrs.Add("actiontype", "highlight");
                        break;
                    case ActionType.ToolTip:
                        node.attrs.Add("actiontype", "tooltip");
                        break;
                    case ActionType.Unknown when actionAttributes.actionString.Length > 0:
                        node.attrs.Add("actiontype", actionAttributes.actionString);
                        break;
                }
                string s = actionAttributes.selection.ToString();
                if (s.Length > 0)
                {
                    node.attrs.Add("selection", s);
                }
            }
        }

        public static void ApplyAttrs(Node node, TableAttributes tableAttributes)
        {
            if (node?.type_ != null && node.type_.type == ElementType.Mtable && tableAttributes != null)
            {
                switch (tableAttributes.align)
                {
                    case TableAlign.TOP:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("align", "top");
                            break;
                        }
                    case TableAlign.BOTTOM:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("align", "bottom");
                            break;
                        }
                    case TableAlign.CENTER:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("align", "center");
                            break;
                        }
                    case TableAlign.BASELINE:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("align", "baseline");
                            break;
                        }
                    case TableAlign.AXIS when node.attrs != null:
                        {
                            Nodes.Attribute attribute = node.attrs.Get("align");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                            break;
                        }
                }
                switch (tableAttributes.side)
                {
                    case Side.LEFT:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("side", "left");
                            break;
                        }
                    case Side.LEFTOVERLAP:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("side", "leftoverlap");
                            break;
                        }
                    case Side.RIGHTOVERLAP:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("side", "rightoverlap");
                            break;
                        }
                    default:
                        {
                            if (node.attrs != null)
                            {
                                Nodes.Attribute attribute = node.attrs.Get("side");
                                if (attribute != null)
                                {
                                    node.attrs.Remove(attribute);
                                }
                            }
                            break;
                        }
                }
                string s = "";
                for (int i = 0; i < tableAttributes.rowAligns.Length; i++)
                {
                    switch (tableAttributes.rowAligns[i])
                    {
                        case RowAlign.TOP:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "top";
                                break;
                            }
                        case RowAlign.BOTTOM:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "bottom";
                                break;
                            }
                        case RowAlign.CENTER:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "center";
                                break;
                            }
                        case RowAlign.AXIS:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "axis";
                                break;
                            }
                        case RowAlign.BASELINE:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "baseline";
                                break;
                            }
                    }
                }
                if (tableAttributes.rowAligns.Length == 1 && s.Trim() == "baseline")
                {
                    if (node.attrs != null)
                    {
                        Nodes.Attribute attribute = node.attrs.Get("rowalign");
                        if (attribute != null)
                        {
                            node.attrs.Remove(attribute);
                        }
                    }
                }
                else
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    if (s.Length > 0)
                    {
                        node.attrs.Add("rowalign", s);
                    }
                }
                string sAlign = "";
                for (int i = 0; i < tableAttributes.colAligns.Length; i++)
                {
                    switch (tableAttributes.colAligns[i])
                    {
                        case HAlign.LEFT:
                            {
                                if (i > 0)
                                {
                                    sAlign = sAlign + " ";
                                }
                                sAlign = sAlign + "left";
                                break;
                            }
                        case HAlign.CENTER:
                            {
                                if (i > 0)
                                {
                                    sAlign = sAlign + " ";
                                }
                                sAlign = sAlign + "center";
                                break;
                            }
                        case HAlign.RIGHT:
                            {
                                if (i > 0)
                                {
                                    sAlign = sAlign + " ";
                                }
                                sAlign = sAlign + "right";
                                break;
                            }
                    }
                }
                if (tableAttributes.colAligns.Length == 1 && sAlign.Trim() == "center")
                {
                    if (node.attrs != null)
                    {
                        Nodes.Attribute attribute = node.attrs.Get("columnalign");
                        if (attribute != null)
                        {
                            node.attrs.Remove(attribute);
                        }
                    }
                }
                else
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    if (sAlign.Length > 0)
                    {
                        node.attrs.Add("columnalign", sAlign);
                    }
                }
                switch (tableAttributes.equalRows)
                {
                    case true:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("equalrows", "True");
                            break;
                        }
                    case false when node.attrs != null:
                        {
                            Nodes.Attribute attribute = node.attrs.Get("equalrows");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                            break;
                        }
                }
                switch (tableAttributes.equalColumns)
                {
                    case true:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("equalcolumns", "True");
                            break;
                        }
                    case false when node.attrs != null:
                        {
                            Nodes.Attribute attribute = node.attrs.Get("equalcolumns");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                            break;
                        }
                }
                switch (tableAttributes.displaystyle)
                {
                    case true:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("displaystyle", "True");
                            break;
                        }
                    case false when node.attrs != null:
                        {
                            Nodes.Attribute attribute = node.attrs.Get("displaystyle");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                            break;
                        }
                }
                if (tableAttributes.framespacing != "0.4em 0.5ex")
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    node.attrs.Add("framespacing", tableAttributes.framespacing);
                }
                else if (tableAttributes.framespacing == "0.4em 0.5ex" && node.attrs != null)
                {
                    Nodes.Attribute attribute = node.attrs.Get("framespacing");
                    if (attribute != null)
                    {
                        node.attrs.Remove(attribute);
                    }
                }
                if (tableAttributes.rowSpacing.Length == 1 && tableAttributes.rowSpacing[0] == "0.5ex")
                {
                    if (node.attrs != null)
                    {
                        Nodes.Attribute attribute = node.attrs.Get("rowspacing");
                        if (attribute != null)
                        {
                            node.attrs.Remove(attribute);
                        }
                    }
                }
                else
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    string ss = "";
                    for (int i = 0; i < tableAttributes.rowSpacing.Length; i++)
                    {
                        if (i > 0)
                        {
                            ss = ss + " ";
                        }
                        ss = ss + tableAttributes.rowSpacing[i];
                    }
                    if (ss.Length > 0)
                    {
                        node.attrs.Add("rowspacing", ss);
                    }
                }
                if (tableAttributes.colSpacing.Length == 1 && tableAttributes.colSpacing[0] == "0.8em")
                {
                    if (node.attrs != null)
                    {
                        Nodes.Attribute attribute = node.attrs.Get("columnspacing");
                        if (attribute != null)
                        {
                            node.attrs.Remove(attribute);
                        }
                    }
                }
                else
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    string ss = "";
                    for (int i = 0; i < tableAttributes.colSpacing.Length; i++)
                    {
                        if (i > 0)
                        {
                            ss = ss + " ";
                        }
                        ss = ss + tableAttributes.colSpacing[i];
                    }
                    if (ss.Length > 0)
                    {
                        node.attrs.Add("columnspacing", ss);
                    }
                }
                switch (tableAttributes.frame)
                {
                    case TableLineStyle.DASHED:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("frame", "dashed");
                            break;
                        }
                    case TableLineStyle.SOLID:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("frame", "solid");
                            break;
                        }
                    case TableLineStyle.NONE when node.attrs != null:
                        {
                            Nodes.Attribute attribute = node.attrs.Get("frame");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                            break;
                        }
                }
                if (tableAttributes.rowLines.Length == 1 && tableAttributes.rowLines[0] == TableLineStyle.NONE)
                {
                    if (node.attrs != null)
                    {
                        Nodes.Attribute attribute = node.attrs.Get("rowlines");
                        if (attribute != null)
                        {
                            node.attrs.Remove(attribute);
                        }
                    }
                }
                else
                {
                    string ss = "";
                    for (int i = 0; i < tableAttributes.rowLines.Length; i++)
                    {
                        switch (tableAttributes.rowLines[i])
                        {
                            case TableLineStyle.DASHED:
                                {
                                    if (i > 0)
                                    {
                                        ss = ss + " ";
                                    }
                                    ss = ss + "dashed";
                                    break;
                                }
                            case TableLineStyle.SOLID:
                                {
                                    if (i > 0)
                                    {
                                        ss = ss + " ";
                                    }
                                    ss = ss + "solid";
                                    break;
                                }
                            case TableLineStyle.NONE:
                                {
                                    if (i > 0)
                                    {
                                        ss = ss + " ";
                                    }
                                    ss = ss + "none";
                                    break;
                                }
                        }
                    }
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    if (ss.Length > 0)
                    {
                        node.attrs.Add("rowlines", ss);
                    }
                }
                if (tableAttributes.colLines.Length == 1 && tableAttributes.colLines[0] == TableLineStyle.NONE)
                {
                    if (node.attrs == null)
                    {
                        return;
                    }
                    Nodes.Attribute attribute = node.attrs.Get("columnlines");
                    if (attribute == null)
                    {
                        return;
                    }
                    node.attrs.Remove(attribute);
                }
                else
                {
                    string ss = "";
                    for (int i = 0; i < tableAttributes.colLines.Length; i++)
                    {
                        switch (tableAttributes.colLines[i])
                        {
                            case TableLineStyle.DASHED:
                                {
                                    if (i > 0)
                                    {
                                        ss = ss + " ";
                                    }
                                    ss = ss + "dashed";
                                    break;
                                }
                            case TableLineStyle.SOLID:
                                {
                                    if (i > 0)
                                    {
                                        ss = ss + " ";
                                    }
                                    ss = ss + "solid";
                                    break;
                                }
                            case TableLineStyle.NONE:
                                {
                                    if (i > 0)
                                    {
                                        ss = ss + " ";
                                    }
                                    ss = ss + "none";
                                    break;
                                }
                        }
                    }
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    if (ss.Length > 0)
                    {
                        node.attrs.Add("columnlines", ss);
                    }
                }
            }
        }

        public static void ApplyAttributes(Node node, TableRowAttributes tableRowAttributes)
        {
            if (node?.type_ != null && (node.type_.type == ElementType.Mtr || node.type_.type == ElementType.Mlabeledtr) && tableRowAttributes != null)
            {
                switch (tableRowAttributes.align)
                {
                    case RowAlign.TOP:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "top");
                            break;
                        }
                    case RowAlign.BOTTOM:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "bottom");
                            break;
                        }
                    case RowAlign.CENTER:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "center");
                            break;
                        }
                    case RowAlign.BASELINE:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "baseline");
                            break;
                        }
                    case RowAlign.AXIS:
                        {
                            if (node.attrs == null)
                            {
                                node.attrs = new AttributeList();
                            }
                            node.attrs.Add("rowalign", "axis");
                            break;
                        }
                    case RowAlign.UNKNOWN when node.attrs != null:
                        {
                            Nodes.Attribute attribute = node.attrs.Get("rowalign");
                            if (attribute != null)
                            {
                                node.attrs.Remove(attribute);
                            }
                            break;
                        }
                }
                string s = "";
                for (int i = 0; i < tableRowAttributes.colAligns.Length; i++)
                {
                    switch (tableRowAttributes.colAligns[i])
                    {
                        case HAlign.LEFT:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "left";
                                break;
                            }
                        case HAlign.CENTER:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "center";
                                break;
                            }
                        case HAlign.RIGHT:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "right";
                                break;
                            }
                        case HAlign.UNKNOWN:
                            {
                                if (i > 0)
                                {
                                    s = s + " ";
                                }
                                s = s + "center";
                                break;
                            }
                    }
                }
                if (tableRowAttributes.colAligns.Length == 1 && s.Trim() == "center")
                {
                    if (node.attrs == null)
                    {
                        return;
                    }
                    Nodes.Attribute attribute = node.attrs.Get("columnalign");
                    if (attribute == null)
                    {
                        return;
                    }
                    node.attrs.Remove(attribute);
                }
                else
                {
                    if (node.attrs == null)
                    {
                        node.attrs = new AttributeList();
                    }
                    if (s.Length > 0)
                    {
                        node.attrs.Add("columnalign", s);
                    }
                }
            }
        }

        public static TableAttributes MTableAttributes(Node node)
        {
            TableAttributes tableAttributes = null;
            try
            {
                if (node.attrs is null) return null;
                node.attrs.Reset();
                Nodes.Attribute attribute;
                for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                {
                    string s = attribute.val.Trim();
                    if (s.Length <= 0) continue;
                    if (tableAttributes == null) tableAttributes = new TableAttributes();
                    switch (attribute.name)
                    {
                        case "align":
                            switch (s.ToUpper())
                            {
                                case "TOP":
                                    tableAttributes.align = TableAlign.TOP;
                                    break;
                                case "BOTTOM":
                                    tableAttributes.align = TableAlign.BOTTOM;
                                    break;
                                case "CENTER":
                                    tableAttributes.align = TableAlign.CENTER;
                                    break;
                                case "BASELINE":
                                    tableAttributes.align = TableAlign.BASELINE;
                                    break;
                                case "AXIS":
                                    tableAttributes.align = TableAlign.AXIS;
                                    break;
                                default:
                                    tableAttributes.align = TableAlign.AXIS;
                                    break;
                            }
                            break;
                        case "side":
                            switch (s.ToUpper())
                            {
                                case "LEFT":
                                    tableAttributes.side = Side.LEFT;
                                    break;
                                case "RIGHT":
                                    tableAttributes.side = Side.RIGHT;
                                    break;
                                case "LEFTOVERLAP":
                                    tableAttributes.side = Side.LEFTOVERLAP;
                                    break;
                                case "RIGHTOVERLAP":
                                    tableAttributes.side = Side.RIGHTOVERLAP;
                                    break;
                            }
                            break;
                        case "minlabelspacing":
                            tableAttributes.minlabelspacing = s.Trim();
                            break;
                        case "rowalign":
                            {
                                s = s.Trim();
                                string[] strings = s.Split(new[] { ' ' }, 100);
                                int numAligns = 0;
                                for (int i = 0; i < strings.Length; i++)
                                {
                                    if (strings[i].ToUpper() == "TOP" || strings[i].ToUpper() == "BOTTOM" || strings[i].ToUpper() == "CENTER" || strings[i].ToUpper() == "BASELINE" || strings[i].ToUpper() == "AXIS")
                                    {
                                        numAligns++;
                                    }
                                }
                                tableAttributes.rowAligns = new RowAlign[numAligns];
                                if (numAligns > 0)
                                {
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        switch (strings[i].ToUpper())
                                        {
                                            case "TOP":
                                                tableAttributes.rowAligns[i] = RowAlign.TOP;
                                                break;
                                            case "BOTTOM":
                                                tableAttributes.rowAligns[i] = RowAlign.BOTTOM;
                                                break;
                                            case "CENTER":
                                                tableAttributes.rowAligns[i] = RowAlign.CENTER;
                                                break;
                                            case "BASELINE":
                                                tableAttributes.rowAligns[i] = RowAlign.BASELINE;
                                                break;
                                            case "AXIS":
                                                tableAttributes.rowAligns[i] = RowAlign.AXIS;
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    tableAttributes.rowAligns = new[] { RowAlign.BASELINE };
                                }
                                break;
                            }
                        case "columnalign":
                            {
                                string[] strings = s.Split(new[] { ' ' }, 100);
                                int numAligns = 0;
                                for (int i = 0; i < strings.Length; i++)
                                {
                                    if (strings[i].ToUpper() == "LEFT" || strings[i].ToUpper() == "CENTER" ||
                                        strings[i].ToUpper() == "RIGHT")
                                    {
                                        numAligns++;
                                    }
                                }
                                tableAttributes.colAligns = new HAlign[numAligns];
                                if (numAligns > 0)
                                {
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        switch (strings[i].ToUpper())
                                        {
                                            case "LEFT":
                                                tableAttributes.colAligns[i] = HAlign.LEFT;
                                                break;
                                            case "CENTER":
                                                tableAttributes.colAligns[i] = HAlign.CENTER;
                                                break;
                                            case "RIGHT":
                                                tableAttributes.colAligns[i] = HAlign.RIGHT;
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    tableAttributes.colAligns = new[] { HAlign.CENTER };
                                }
                            }
                            break;
                        case "frame":
                            switch (s.ToUpper())
                            {
                                case "SOLID":
                                    tableAttributes.frame = TableLineStyle.SOLID;
                                    break;
                                case "DASHED":
                                    tableAttributes.frame = TableLineStyle.DASHED;
                                    break;
                                default:
                                    tableAttributes.frame = TableLineStyle.NONE;
                                    break;
                            }
                            break;
                        case "framespacing":
                            tableAttributes.framespacing = s;
                            break;
                        case "rowspacing":
                            {
                                s = s.Trim();
                                string[] strings = s.Split(new[] { ' ' }, 100);
                                if (strings.Length > 0)
                                {
                                    tableAttributes.rowSpacing = new string[strings.Length];
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        tableAttributes.rowSpacing[i] = strings[i];
                                    }
                                }
                            }
                            break;
                        case "columnspacing":
                            {
                                s = s.Trim();
                                string[] strings = s.Split(new char[] { ' ' }, 100);
                                if (strings.Length > 0)
                                {
                                    tableAttributes.colSpacing = new string[strings.Length];
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        tableAttributes.colSpacing[i] = strings[i];
                                    }
                                }
                            }
                            break;
                        case "rowlines":
                            {
                                s = s.Trim();
                                string[] strings = s.Split(new char[] { ' ' }, 100);
                                int numLines = 0;
                                if (strings.Length > 0)
                                {
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        if (strings[i].ToUpper() == "NONE" || strings[i].ToUpper() == "SOLID" ||
                                            strings[i].ToUpper() == "DASHED")
                                        {
                                            numLines++;
                                        }
                                    }
                                }
                                if (numLines > 0)
                                {
                                    if (tableAttributes == null)
                                    {
                                        tableAttributes = new TableAttributes();
                                    }
                                    tableAttributes.rowLines = new TableLineStyle[numLines];
                                    int lineIndex = 0;
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        switch (strings[i].ToUpper())
                                        {
                                            case "SOLID":
                                                tableAttributes.rowLines[lineIndex] = TableLineStyle.SOLID;
                                                lineIndex++;
                                                break;
                                            case "DASHED":
                                                tableAttributes.rowLines[lineIndex] = TableLineStyle.DASHED;
                                                lineIndex++;
                                                break;
                                            case "NONE":
                                                tableAttributes.rowLines[lineIndex] = TableLineStyle.NONE;
                                                lineIndex++;
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                        case "columnlines":
                            {
                                s = s.Trim();
                                string[] strings = s.Split(new[] { ' ' }, 100);
                                int numLines = 0;
                                if (strings.Length > 0)
                                {
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        if (strings[i].ToUpper() == "NONE" || strings[i].ToUpper() == "SOLID" ||
                                            strings[i].ToUpper() == "DASHED")
                                        {
                                            numLines++;
                                        }
                                    }
                                }
                                if (numLines > 0)
                                {
                                    if (tableAttributes == null)
                                    {
                                        tableAttributes = new TableAttributes();
                                    }
                                    tableAttributes.colLines = new TableLineStyle[numLines];
                                    int lineIndex = 0;
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        switch (strings[i].ToUpper())
                                        {
                                            case "SOLID":
                                                tableAttributes.colLines[lineIndex] = TableLineStyle.SOLID;
                                                lineIndex++;
                                                break;
                                            case "DASHED":
                                                tableAttributes.colLines[lineIndex] = TableLineStyle.DASHED;
                                                lineIndex++;
                                                break;
                                            case "NONE":
                                                tableAttributes.colLines[lineIndex] = TableLineStyle.NONE;
                                                lineIndex++;
                                                break;
                                        }
                                    }
                                }
                            }
                            break;
                        case "equalrows":
                            tableAttributes.equalRows = Convert.ToBoolean(s);
                            break;
                        case "equalcolumns":
                            tableAttributes.equalColumns = Convert.ToBoolean(s);
                            break;
                        case "displaystyle":
                            tableAttributes.displaystyle = Convert.ToBoolean(s);
                            break;
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
            return tableAttributes;
        }

        public static TableRowAttributes MTableRowAttributes(Node node)
        {
            Nodes.Attribute attribute = null;
            TableRowAttributes tableRowAttributes = null;
            try
            {
                if (node.attrs != null)
                {
                    node.attrs.Reset();
                    for (attribute = node.attrs.Next(); attribute != null; attribute = node.attrs.Next())
                    {
                        string s = attribute.val.Trim();

                        if (s.Length <= 0) continue;
                        if (tableRowAttributes == null) tableRowAttributes = new TableRowAttributes();
                        switch (attribute.name)
                        {
                            case "rowalign":
                                switch (s.ToUpper())
                                {
                                    case "TOP":
                                        tableRowAttributes.align = RowAlign.TOP;
                                        break;
                                    case "BOTTOM":
                                        tableRowAttributes.align = RowAlign.BOTTOM;
                                        break;
                                    case "CENTER":
                                        tableRowAttributes.align = RowAlign.CENTER;
                                        break;
                                    case "BASELINE":
                                        tableRowAttributes.align = RowAlign.BASELINE;
                                        break;
                                    case "AXIS":
                                        tableRowAttributes.align = RowAlign.AXIS;
                                        break;
                                    default:
                                        tableRowAttributes.align = RowAlign.UNKNOWN;
                                        break;
                                }
                                break;
                            case "columnalign":
                                {
                                    string[] strings = s.Split(new[] { ' ' }, 100);
                                    int numAligns = 0;
                                    for (int i = 0; i < strings.Length; i++)
                                    {
                                        if (strings[i].ToUpper() == "LEFT" || strings[i].ToUpper() == "CENTER" ||
                                            strings[i].ToUpper() == "RIGHT")
                                        {
                                            numAligns++;
                                        }
                                    }
                                    tableRowAttributes.colAligns = new HAlign[numAligns];
                                    if (numAligns > 0)
                                    {
                                        for (int i = 0; i < strings.Length; i++)
                                        {
                                            switch (strings[i].ToUpper())
                                            {
                                                case "LEFT":
                                                    tableRowAttributes.colAligns[i] = HAlign.LEFT;
                                                    break;
                                                case "CENTER":
                                                    tableRowAttributes.colAligns[i] = HAlign.CENTER;
                                                    break;
                                                case "RIGHT":
                                                    tableRowAttributes.colAligns[i] = HAlign.RIGHT;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        tableRowAttributes.colAligns = new[] { HAlign.CENTER };
                                    }
                                    break;
                                }
                        }
                    }
                }
                node.attrs?.Reset();
            }
            catch
            {
            }
            return tableRowAttributes;
        }

        public static TableCellAttributes MTableCellAttributes(Node node)
        {
            TableCellAttributes tableCellAttributes = null;
            try
            {
                if (node.attrs is null) return null;
                node.attrs.Reset();
                for (var n = node.attrs.Next(); n != null; n = node.attrs.Next())
                {
                    string s = n.val.Trim();
                    if (s.Length <= 0) continue;
                    if (tableCellAttributes == null) tableCellAttributes = new TableCellAttributes();
                    switch (n.name)
                    {
                        case "rowalign":
                            switch (s.ToUpper())
                            {
                                case "TOP":
                                    tableCellAttributes.rowAlign = RowAlign.TOP;
                                    break;
                                case "BOTTOM":
                                    tableCellAttributes.rowAlign = RowAlign.BOTTOM;
                                    break;
                                case "CENTER":
                                    tableCellAttributes.rowAlign = RowAlign.CENTER;
                                    break;
                                case "BASELINE":
                                    tableCellAttributes.rowAlign = RowAlign.BASELINE;
                                    break;
                                case "AXIS":
                                    tableCellAttributes.rowAlign = RowAlign.AXIS;
                                    break;
                                default:
                                    tableCellAttributes.rowAlign = RowAlign.CENTER;
                                    break;
                            }
                            break;
                        case "columnalign":
                            switch (s.ToUpper())
                            {
                                case "LEFT":
                                    tableCellAttributes.columnAlign = HAlign.LEFT;
                                    break;
                                case "CENTER":
                                    tableCellAttributes.columnAlign = HAlign.CENTER;
                                    break;
                                case "RIGHT":
                                    tableCellAttributes.columnAlign = HAlign.RIGHT;
                                    break;
                                default:
                                    tableCellAttributes.columnAlign = HAlign.LEFT;
                                    break;
                            }
                            break;
                        case "rowspan":
                            tableCellAttributes.rowSpan = Convert.ToInt32(s.Trim());
                            break;
                        case "columnspan":
                            tableCellAttributes.columnSpan = Convert.ToInt32(s.Trim());
                            break;
                    }
                }
                node.attrs.Reset();
            }
            catch
            {
            }
            return tableCellAttributes;
        }
    }
}