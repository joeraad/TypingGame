using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class TrainingWordDisplay : MonoBehaviour
{

    public TextMeshProUGUI textField;

    public TMP_CharacterInfo CharacterInfo;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        textField.text = "This cow is\nbig!";
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCharacterColor(int index, bool isCorrect)
    {
        TMP_TextInfo textInfo = textField.textInfo;
        Color32[] newVertexColors;
        Color32 c0 = textField.color;
        int characterCount = textInfo.characterCount;

        // If No Characters then just yield and wait for some text to be added
        if (characterCount == 0)
        {
            return;
        }



        CharacterInfo = textInfo.characterInfo[index];
/*
        float CharacterTopLeftPositionX = CharacterInfo.vertex_TL.position.x;
        float CharacterTopLeftPositionY = CharacterInfo.vertex_TL.position.y;
        float CharacterBottomRightPositionX = CharacterInfo.vertex_BR.position.x;
        float CharacterBottomRightPositionY = CharacterInfo.vertex_BR.position.y;
 */
        float CharacterTopLeftPositionX = CharacterInfo.topLeft.x;
        float CharacterTopLeftPositionY = CharacterInfo.topLeft.y;
        float CharacterBottomRightPositionX = CharacterInfo.bottomLeft.x;
        float CharacterBottomRightPositionY = CharacterInfo.bottomLeft.y;

        Debug.Log("These are the points:\n" + CharacterTopLeftPositionX + " " + CharacterTopLeftPositionY + "\n" + CharacterBottomRightPositionX + " " + CharacterBottomRightPositionY);

        Vector3 characterPosition = transform.TransformVector(((CharacterTopLeftPositionX + CharacterBottomRightPositionX) / 2), ((CharacterTopLeftPositionY + CharacterBottomRightPositionY) / 2), 0);
        Debug.Log(characterPosition);
        panel.transform.position = characterPosition;

        //panel.transform.position= textField.transform.localToWorldMatrix.MultiplyPoint(characterPosition);
        //textField.transform.localToWorldMatrix.MultiplyPoint(characterPosition);


        /*
                CharacterInfo = textInfo.characterInfo[index];
                Vector3 characterPositions=CharacterInfo.vertex_BR.position;
                panel.transform.position = textField.transform.localToWorldMatrix.MultiplyPoint3x4(characterPositions);
        */

        // Get the index of the material used by the current character.
        int materialIndex = textInfo.characterInfo[index].materialReferenceIndex;
        // Get the vertex colors of the mesh used by this text element (character or sprite).
        newVertexColors = textInfo.meshInfo[materialIndex].colors32;
        // Get the index of the first vertex used by this text element.
        int vertexIndex = textInfo.characterInfo[index].vertexIndex;
        // Only change the vertex color if the text element is visible.
        if (textInfo.characterInfo[index].isVisible)
        {
            if (isCorrect)
            {
                c0 = new Color32(0, 255, 0, 255);
            }
            else
            {
                c0 = new Color32(255, 0, 0, 255);
            }
           
            newVertexColors[vertexIndex + 0] = c0;
            newVertexColors[vertexIndex + 1] = c0;
            newVertexColors[vertexIndex + 2] = c0;
            newVertexColors[vertexIndex + 3] = c0;

            // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
            textField.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

            // This last process could be done to only update the vertex data that has changed as opposed to all of the vertex data but it would require extra steps and knowing what type of renderer is used.
            // These extra steps would be a performance optimization but it is unlikely that such optimization will be necessary.
        }

        
       
        

    }

    /*
    using UnityEngine;
    using System.Collections;


    namespace TMPro.Examples
    {

        public class VertexColorCycler : MonoBehaviour
        {

            private TMP_Text m_TextComponent;

            void Awake()
            {
                m_TextComponent = GetComponent<TMP_Text>();
            }


            void Start()
            {
                StartCoroutine(AnimateVertexColors());
            }


            /// <summary>
            /// Method to animate vertex colors of a TMP Text object.
            /// </summary>
            /// <returns></returns>
            IEnumerator AnimateVertexColors()
            {
                TMP_TextInfo textInfo = m_TextComponent.textInfo;
                int currentCharacter = 0;

                Color32[] newVertexColors;
                Color32 c0 = m_TextComponent.color;

                while (true)
                {
                    int characterCount = textInfo.characterCount;

                    // If No Characters then just yield and wait for some text to be added
                    if (characterCount == 0)
                    {
                        yield return new WaitForSeconds(0.25f);
                        continue;
                    }

                    // Get the index of the material used by the current character.
                    int materialIndex = textInfo.characterInfo[currentCharacter].materialReferenceIndex;

                    // Get the vertex colors of the mesh used by this text element (character or sprite).
                    newVertexColors = textInfo.meshInfo[materialIndex].colors32;

                    // Get the index of the first vertex used by this text element.
                    int vertexIndex = textInfo.characterInfo[currentCharacter].vertexIndex;

                    // Only change the vertex color if the text element is visible.
                    if (textInfo.characterInfo[currentCharacter].isVisible)
                    {
                        c0 = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);

                        newVertexColors[vertexIndex + 0] = c0;
                        newVertexColors[vertexIndex + 1] = c0;
                        newVertexColors[vertexIndex + 2] = c0;
                        newVertexColors[vertexIndex + 3] = c0;

                        // New function which pushes (all) updated vertex data to the appropriate meshes when using either the Mesh Renderer or CanvasRenderer.
                        m_TextComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

                        // This last process could be done to only update the vertex data that has changed as opposed to all of the vertex data but it would require extra steps and knowing what type of renderer is used.
                        // These extra steps would be a performance optimization but it is unlikely that such optimization will be necessary.
                    }

                    currentCharacter = (currentCharacter + 1) % characterCount;

                    yield return new WaitForSeconds(0.05f);
                }
            }

        }
    }
    */


}
