using System;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace Stalo.ShaderUtils.Editor.Drawers
{
    [PublicAPI]
    internal class HelpBoxDecorator : MaterialPropertyDrawer
    {
        private readonly MessageType m_MsgType;
        private readonly string m_Message;

        public HelpBoxDecorator(string msgType, params string[] messages)
        {
            m_MsgType = Enum.Parse<MessageType>(msgType);
            m_Message = string.Join(", ", messages);
        }

        public override float GetPropertyHeight(MaterialProperty prop, string label, MaterialEditor editor)
        {
            float offset = EditorGUIUtility.standardVerticalSpacing * 2;
            GUIContent content = EditorGUIUtility.TrTextContentWithIcon(m_Message, m_MsgType);
            return offset + EditorStyles.helpBox.CalcHeight(content, EditorGUIUtility.currentViewWidth - 43);
        }

        public override void OnGUI(Rect position, MaterialProperty prop, string label, MaterialEditor editor)
        {
            position.y += EditorGUIUtility.standardVerticalSpacing;
            position.height -= EditorGUIUtility.standardVerticalSpacing * 2;
            EditorGUI.HelpBox(position, m_Message, m_MsgType);
        }
    }
}
