using System;
using System.Collections.Generic;
/*
 * Copyright 2004 Paulo Soares
 *
 * The contents of this file are subject to the Mozilla Public License Version 1.1
 * (the "License"); you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at http://www.mozilla.org/MPL/
 *
 * Software distributed under the License is distributed on an "AS IS" basis,
 * WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
 * for the specific language governing rights and limitations under the License.
 *
 * The Original Code is 'iText, a free JAVA-PDF library'.
 *
 * The Initial Developer of the Original Code is Bruno Lowagie. Portions created by
 * the Initial Developer are Copyright (C) 1999, 2000, 2001, 2002 by Bruno Lowagie.
 * All Rights Reserved.
 * Co-Developer of the code is Paulo Soares. Portions created by the Co-Developer
 * are Copyright (C) 2000, 2001, 2002 by Paulo Soares. All Rights Reserved.
 *
 * Contributor(s): all the names of the contributors are added in the source code
 * where applicable.
 *
 * Alternatively, the contents of this file may be used under the terms of the
 * LGPL license (the "GNU LIBRARY GENERAL PUBLIC LICENSE"), in which case the
 * provisions of LGPL are applicable instead of those above.  If you wish to
 * allow use of your version of this file only under the terms of the LGPL
 * License and not to allow others to use your version of this file under
 * the MPL, indicate your decision by deleting the provisions above and
 * replace them with the notice and other provisions required by the LGPL.
 * If you do not delete the provisions above, a recipient may use your version
 * of this file under either the MPL or the GNU LIBRARY GENERAL PUBLIC LICENSE.
 *
 * This library is free software; you can redistribute it and/or modify it
 * under the terms of the MPL as stated above or under the terms of the GNU
 * Library General Public License as published by the Free Software Foundation;
 * either version 2 of the License, or any later version.
 *
 * This library is distributed in the hope that it will be useful, but WITHOUT
 * ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
 * FOR A PARTICULAR PURPOSE. See the GNU Library general Public License for more
 * details.
 *
 * If you didn't download this code from the following link, you should check if
 * you aren't using an obsolete version:
 * http://www.lowagie.com/iText/
 */

namespace iTextSharp.text.html.simpleparser {

    public class StyleSheet {
        
        public IDictionary<string, IDictionary<string, string>> classMap = new GenericHashTable<string, IDictionary<string, string>>();
        public IDictionary<string, IDictionary<string, string>> tagMap = new GenericHashTable<string, IDictionary<string, string>>();
        
        /** Creates a new instance of StyleSheet */
        public StyleSheet() {
        }
        
        public void ApplyStyle(String tag, GenericHashTable<string, string> props) {
            tagMap.TryGetValue(tag.ToLower(System.Globalization.CultureInfo.InvariantCulture), out var map);
            if (map != null) {
                var temp = new GenericHashTable<string, string>(map);
                foreach (var dc in props)
                    temp[dc.Key] = dc.Value;
                foreach (var dc in temp)
                    props[dc.Key] = dc.Value;
            }
            String cm = (String)props[Markup.HTML_ATTR_CSS_CLASS];
            if (cm == null)
                return;
            classMap.TryGetValue(cm.ToLower(System.Globalization.CultureInfo.InvariantCulture), out map);
            if (map == null)
                return;
            props.Remove(Markup.HTML_ATTR_CSS_CLASS);
            var temp1 = new GenericHashTable<string, string>(map);
            foreach (var dc in props)
                temp1[dc.Key] = dc.Value;
            foreach (var dc in temp1)
                props[dc.Key] = dc.Value;
        }

        public void LoadStyle(String style, GenericHashTable<string, string> props) {
            classMap[style.ToLower(System.Globalization.CultureInfo.InvariantCulture)] = props;
        }

        public void LoadStyle(String style, String key, String value) {
            style = style.ToLower(System.Globalization.CultureInfo.InvariantCulture);
            classMap.TryGetValue(style, out var props);
            if (props == null) {
                props = new GenericHashTable<string, string>();
                classMap[style] = props;
            }
            props[key] = value;
        }
        
        public void LoadTagStyle(String tag, GenericHashTable<string, string> props) {
            tagMap[tag.ToLower(System.Globalization.CultureInfo.InvariantCulture)] = props;
        }

        public void LoadTagStyle(String tag, String key, String value) {
            tag = tag.ToLower(System.Globalization.CultureInfo.InvariantCulture);
            tagMap.TryGetValue(tag, out var props);
            if (props == null) {
                props = new GenericHashTable<string, string>();
                tagMap[tag] = props;
            }
            props[key] = value;
        }
    }
}