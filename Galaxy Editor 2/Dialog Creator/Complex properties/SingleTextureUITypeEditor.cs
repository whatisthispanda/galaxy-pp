﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Galaxy_Editor_2.Dialog_Creator.Controls;

namespace Galaxy_Editor_2.Dialog_Creator.Complex_properties
{
    class SingleTextureUITypeEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            GraphicsControl graphicsContext;
            if (context.Instance is AbstractControl)
                graphicsContext = ((AbstractControl) context.Instance).Context;
            else
                throw new Exception("Unable to find context from Type Editor");

            TextureBrowserDialog dialog = new TextureBrowserDialog(value is SingleTextureProperty ? ((SingleTextureProperty)value).Path : "");
            if (dialog.ShowDialog() == DialogResult.OK)
                return new SingleTextureProperty(dialog.SelectedPath, dialog.SelectedTexture, graphicsContext);
            return value;
            
        }
    }
}
