using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

namespace Gamekit3D
{
    [CustomEditor(typeof(PlayerController))]
    public class PlayerControllerEditor : Editor
    {
        SerializedProperty m_ScriptProp;

        SerializedProperty m_MaxForwardSpeedProp;
        SerializedProperty m_GravityProp;
        SerializedProperty m_JumpSpeedProp;
        SerializedProperty m_MinTurnSpeedProp;
        SerializedProperty m_MaxTurnSpeedProp;
        SerializedProperty m_IdleTimeoutProp;
        SerializedProperty m_CanAttackProp;
        
        SerializedProperty m_MaxForwardSpeedEProp;
        SerializedProperty m_GravityEProp;
        SerializedProperty m_JumpSpeedEProp;
        SerializedProperty m_MinTurnSpeedEProp;
        SerializedProperty m_MaxTurnSpeedEProp;
        SerializedProperty m_IdleTimeoutEProp;
        SerializedProperty m_CanAttackEProp;

        SerializedProperty m_MaxForwardSpeedCProp;
        SerializedProperty m_GravityCProp;
        SerializedProperty m_JumpSpeedCProp;
        SerializedProperty m_MinTurnSpeedCProp;
        SerializedProperty m_MaxTurnSpeedCProp;
        SerializedProperty m_IdleTimeoutCProp;
        SerializedProperty m_CanAttackCProp;

        SerializedProperty m_MeleeWeaponProp;
        SerializedProperty m_CameraSettingsProp;
        SerializedProperty m_FootstepPlayerProp;
        SerializedProperty m_HurtAudioPlayerProp;
        SerializedProperty m_LandingPlayerProp;
        SerializedProperty m_EmoteLandingPlayerProp;
        SerializedProperty m_EmoteDeathPlayerProp;
        SerializedProperty m_EmoteAttackPlayerProp;
        SerializedProperty m_EmoteJumpPlayerProp;

        GUIContent m_ScriptContent = new GUIContent("Script");

        GUIContent m_MaxForwardSpeedContent = new GUIContent("Max Forward Speed", "How fast PIRATE Ellen can run.");
        GUIContent m_GravityContent = new GUIContent("Gravity", "How fast Ellen falls when in the air.");
        GUIContent m_JumpSpeedContent = new GUIContent("Jump Speed", "How fast Ellen takes off when jumping.");
        GUIContent m_TurnSpeedContent = new GUIContent("Turn Speed", "How fast Ellen turns.  This varies depending on how fast she is moving.  When stationary the maximum will be used and when running at Max Forward Speed the minimum will be used.");
        GUIContent m_IdleTimeoutContent = new GUIContent("Idle Timeout", "How many seconds before Ellen starts considering random Idle poses.");
        GUIContent m_CanAttackContent = new GUIContent("Can Attack", "Whether or not Ellen can attack with her staff.  This can be set externally.");

        GUIContent m_MaxForwardSpeedEContent = new GUIContent("Max Forward Speed E", "How fast PIRATE CAPTAIN can run.");
        GUIContent m_GravityEContent = new GUIContent("Gravity E", "How fast Ellen falls when in the air.");
        GUIContent m_JumpSpeedEContent = new GUIContent("Jump Speed E", "How fast Ellen takes off when jumping.");
        GUIContent m_TurnSpeedEContent = new GUIContent("Turn Speed E", "How fast Ellen turns.  This varies depending on how fast she is moving.  When stationary the maximum will be used and when running at Max Forward Speed the minimum will be used.");
        GUIContent m_IdleTimeoutEContent = new GUIContent("Idle Timeout E", "How many seconds before Ellen starts considering random Idle poses.");
        GUIContent m_CanAttackEContent = new GUIContent("Can Attack E", "Whether or not Ellen can attack with her staff.  This can be set externally.");

        GUIContent m_MaxForwardSpeedCContent = new GUIContent("Max Forward Speed C", "How fast PIRATE CAPTAIN can run.");
        GUIContent m_GravityCContent = new GUIContent("Gravity C", "How fast Ellen falls when in the air.");
        GUIContent m_JumpSpeedCContent = new GUIContent("Jump Speed C", "How fast Ellen takes off when jumping.");
        GUIContent m_TurnSpeedCContent = new GUIContent("Turn Speed C", "How fast Ellen turns.  This varies depending on how fast she is moving.  When stationary the maximum will be used and when running at Max Forward Speed the minimum will be used.");
        GUIContent m_IdleTimeoutCContent = new GUIContent("Idle Timeout C", "How many seconds before Ellen starts considering random Idle poses.");
        GUIContent m_CanAttackCContent = new GUIContent("Can Attack C", "Whether or not Ellen can attack with her staff.  This can be set externally.");

        GUIContent m_MeleeWeaponContent = new GUIContent("Melee Weapon", "Used for damaging enemies when Ellen swings her staff.");
        GUIContent m_CameraSettingsContent = new GUIContent("Camera Settings", "Used to get the rotation of the current camera so that Ellen faces the correct direction.  Note: This is the only reference which is not part of the Ellen prefab.  It should automatically be set to the Camera Settings script of the CameraRig gameobject when the Prefab is instantiated.");
        GUIContent m_FootstepPlayerContent = new GUIContent("Footstep Random Audio Player", "Used to play a random sound when Ellen takes a step.");
        GUIContent m_HurtAudioPlayerContent = new GUIContent("Hurt Random Audio Player", "Used to play a random sound when Ellen gets hurt.");
        GUIContent m_LandingPlayerContent = new GUIContent("Landing Random Audio Player", "Used to play a random sound when Ellen lands.");
        GUIContent m_EmoteLandingPlayerContent = new GUIContent("Emote Landing Player", "Used to play a random vocal sound when Ellen lands.");
        GUIContent m_EmoteDeathPlayerContent = new GUIContent("Emote Death Player", "Used to play a random vocal sound when Ellen dies.");
        GUIContent m_EmoteAttackPlayerContent = new GUIContent("Emote Attack Player", "Used to play a random vocal sound when Ellen attacks.");
        GUIContent m_EmoteJumpPlayerContent = new GUIContent("Emote Jump Player", "Used to play a random vocal sound when Ellen jumps.");

        void OnEnable()
        {
            m_ScriptProp = serializedObject.FindProperty("m_Script");

            m_MaxForwardSpeedProp = serializedObject.FindProperty("maxForwardSpeed");
            m_GravityProp = serializedObject.FindProperty("gravity");
            m_JumpSpeedProp = serializedObject.FindProperty("jumpSpeed");
            m_MinTurnSpeedProp = serializedObject.FindProperty("minTurnSpeed");
            m_MaxTurnSpeedProp = serializedObject.FindProperty("maxTurnSpeed");
            m_IdleTimeoutProp = serializedObject.FindProperty("idleTimeout");
            m_CanAttackProp = serializedObject.FindProperty("canAttack");

            m_MaxForwardSpeedEProp = serializedObject.FindProperty("maxForwardSpeedE");
            m_GravityEProp = serializedObject.FindProperty("gravityE");
            m_JumpSpeedEProp = serializedObject.FindProperty("jumpSpeedE");
            m_MinTurnSpeedEProp = serializedObject.FindProperty("minTurnSpeedE");
            m_MaxTurnSpeedEProp = serializedObject.FindProperty("maxTurnSpeedE");
            m_IdleTimeoutEProp = serializedObject.FindProperty("idleTimeoutE");
            m_CanAttackEProp = serializedObject.FindProperty("canAttackE");

            m_MaxForwardSpeedCProp = serializedObject.FindProperty("maxForwardSpeedC");
            m_GravityCProp = serializedObject.FindProperty("gravityC");
            m_JumpSpeedCProp = serializedObject.FindProperty("jumpSpeedC");
            m_MinTurnSpeedCProp = serializedObject.FindProperty("minTurnSpeedC");
            m_MaxTurnSpeedCProp = serializedObject.FindProperty("maxTurnSpeedC");
            m_IdleTimeoutCProp = serializedObject.FindProperty("idleTimeoutC");
            m_CanAttackCProp = serializedObject.FindProperty("canAttackC");
            
            m_MeleeWeaponProp = serializedObject.FindProperty("meleeWeapon");
            m_CameraSettingsProp = serializedObject.FindProperty("cameraSettings");
            m_FootstepPlayerProp = serializedObject.FindProperty("footstepPlayer");
            m_HurtAudioPlayerProp = serializedObject.FindProperty("hurtAudioPlayer");
            m_LandingPlayerProp = serializedObject.FindProperty("landingPlayer");
            m_EmoteLandingPlayerProp = serializedObject.FindProperty("emoteLandingPlayer");
            m_EmoteDeathPlayerProp = serializedObject.FindProperty("emoteDeathPlayer");
            m_EmoteAttackPlayerProp = serializedObject.FindProperty("emoteAttackPlayer");
            m_EmoteJumpPlayerProp = serializedObject.FindProperty("emoteJumpPlayer");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUI.enabled = false;
            EditorGUILayout.PropertyField(m_ScriptProp, m_ScriptContent);
            GUI.enabled = true;

            EditorGUILayout.LabelField("ACTIVE Pirate Settings:");

            m_MaxForwardSpeedProp.floatValue =
                EditorGUILayout.Slider(m_MaxForwardSpeedContent, m_MaxForwardSpeedProp.floatValue, 4f, 12f);
            m_GravityProp.floatValue = EditorGUILayout.Slider(m_GravityContent, m_GravityProp.floatValue, 10f, 30f);
            m_JumpSpeedProp.floatValue =
                EditorGUILayout.Slider(m_JumpSpeedContent, m_JumpSpeedProp.floatValue, 5f, 20f);

            MinMaxTurnSpeed(0);

            EditorGUILayout.PropertyField(m_IdleTimeoutProp, m_IdleTimeoutContent);
            EditorGUILayout.PropertyField(m_CanAttackProp, m_CanAttackContent);

            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("Pirate ELLEN Settings:");
            
            m_MaxForwardSpeedEProp.floatValue = EditorGUILayout.Slider(m_MaxForwardSpeedEContent, m_MaxForwardSpeedEProp.floatValue, 4f, 12f);
            m_GravityEProp.floatValue = EditorGUILayout.Slider(m_GravityEContent, m_GravityEProp.floatValue, 10f, 30f);
            m_JumpSpeedEProp.floatValue = EditorGUILayout.Slider(m_JumpSpeedEContent, m_JumpSpeedEProp.floatValue, 5f, 20f);

            MinMaxTurnSpeed(1);

            EditorGUILayout.PropertyField(m_IdleTimeoutEProp, m_IdleTimeoutEContent);
            EditorGUILayout.PropertyField(m_CanAttackEProp, m_CanAttackEContent);
            
            EditorGUILayout.Space();            
            
            EditorGUILayout.LabelField("Pirate CAPTAIN Settings:");
            
            m_MaxForwardSpeedCProp.floatValue = EditorGUILayout.Slider(m_MaxForwardSpeedCContent, m_MaxForwardSpeedCProp.floatValue, 4f, 12f);
            m_GravityCProp.floatValue = EditorGUILayout.Slider(m_GravityCContent, m_GravityCProp.floatValue, 10f, 30f);
            m_JumpSpeedCProp.floatValue = EditorGUILayout.Slider(m_JumpSpeedCContent, m_JumpSpeedCProp.floatValue, 5f, 20f);

            MinMaxTurnSpeed(2);

            EditorGUILayout.PropertyField(m_IdleTimeoutCProp, m_IdleTimeoutCContent);
            EditorGUILayout.PropertyField(m_CanAttackCProp, m_CanAttackCContent);
            
            EditorGUILayout.Space();
            
            m_MeleeWeaponProp.isExpanded = EditorGUILayout.Foldout(m_MeleeWeaponProp.isExpanded, "References");

            if (m_MeleeWeaponProp.isExpanded)
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PropertyField(m_MeleeWeaponProp, m_MeleeWeaponContent);
                EditorGUILayout.PropertyField(m_CameraSettingsProp, m_CameraSettingsContent);
                EditorGUILayout.PropertyField(m_FootstepPlayerProp, m_FootstepPlayerContent);
                EditorGUILayout.PropertyField(m_HurtAudioPlayerProp, m_HurtAudioPlayerContent);
                EditorGUILayout.PropertyField(m_LandingPlayerProp, m_LandingPlayerContent);
                EditorGUILayout.PropertyField(m_EmoteLandingPlayerProp, m_EmoteLandingPlayerContent);
                EditorGUILayout.PropertyField(m_EmoteDeathPlayerProp, m_EmoteDeathPlayerContent);
                EditorGUILayout.PropertyField(m_EmoteAttackPlayerProp, m_EmoteAttackPlayerContent);
                EditorGUILayout.PropertyField(m_EmoteJumpPlayerProp, m_EmoteJumpPlayerContent);
                EditorGUI.indentLevel--;
            }

            serializedObject.ApplyModifiedProperties();
        }

        void MinMaxTurnSpeed(int cap)
        {
            Rect position = EditorGUILayout.GetControlRect(false, EditorGUIUtility.singleLineHeight);

            const float spacing = 4f;
            const float intFieldWidth = 50f;

            position.width -= spacing * 3f + intFieldWidth * 2f;

            Rect labelRect = position;
            labelRect.width *= 0.48f;

            Rect minRect = position;
            minRect.width = 50f;
            minRect.x += labelRect.width + spacing;

            Rect sliderRect = position;
            sliderRect.width *= 0.52f;
            sliderRect.x += labelRect.width + minRect.width + spacing * 2f;

            Rect maxRect = position;
            maxRect.width = minRect.width;
            maxRect.x += labelRect.width + minRect.width + sliderRect.width + spacing * 3f;

            if (cap == 0)
            {
                EditorGUI.LabelField(labelRect, m_TurnSpeedContent);
                m_MinTurnSpeedProp.floatValue = EditorGUI.IntField(minRect, (int)m_MinTurnSpeedProp.floatValue);

                float minTurnSpeed = m_MinTurnSpeedProp.floatValue;
                float maxTurnSpeed = m_MaxTurnSpeedProp.floatValue;
                EditorGUI.MinMaxSlider(sliderRect, GUIContent.none, ref minTurnSpeed, ref maxTurnSpeed, 100f, 1500f);
                m_MinTurnSpeedProp.floatValue = minTurnSpeed;
                m_MaxTurnSpeedProp.floatValue = maxTurnSpeed;

                m_MaxTurnSpeedProp.floatValue = EditorGUI.IntField(maxRect, (int)m_MaxTurnSpeedProp.floatValue);              
            }
            else if (cap == 1)
            {
                EditorGUI.LabelField(labelRect, m_TurnSpeedEContent);
                m_MinTurnSpeedEProp.floatValue = EditorGUI.IntField(minRect, (int)m_MinTurnSpeedEProp.floatValue);

                float minTurnSpeedE = m_MinTurnSpeedEProp.floatValue;
                float maxTurnSpeedE = m_MaxTurnSpeedEProp.floatValue;
                EditorGUI.MinMaxSlider(sliderRect, GUIContent.none, ref minTurnSpeedE, ref maxTurnSpeedE, 100f, 1500f);
                m_MinTurnSpeedEProp.floatValue = minTurnSpeedE;
                m_MaxTurnSpeedEProp.floatValue = maxTurnSpeedE;

                m_MaxTurnSpeedEProp.floatValue = EditorGUI.IntField(maxRect, (int)m_MaxTurnSpeedEProp.floatValue);
            }
            else if (cap == 2)
            {
                EditorGUI.LabelField(labelRect, m_TurnSpeedCContent);
                m_MinTurnSpeedCProp.floatValue = EditorGUI.IntField(minRect, (int)m_MinTurnSpeedCProp.floatValue);

                float minTurnSpeedC = m_MinTurnSpeedCProp.floatValue;
                float maxTurnSpeedC = m_MaxTurnSpeedCProp.floatValue;
                EditorGUI.MinMaxSlider(sliderRect, GUIContent.none, ref minTurnSpeedC, ref maxTurnSpeedC, 100f, 1500f);
                m_MinTurnSpeedCProp.floatValue = minTurnSpeedC;
                m_MaxTurnSpeedCProp.floatValue = maxTurnSpeedC;

                m_MaxTurnSpeedCProp.floatValue = EditorGUI.IntField(maxRect, (int)m_MaxTurnSpeedCProp.floatValue);
            }

        }
    } 
}
