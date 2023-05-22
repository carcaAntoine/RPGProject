using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Tooltip : MonoBehaviour
{
    [SerializeField] private TMP_Text headerField;
    [SerializeField] private TMP_Text contentField;
    [SerializeField] private LayoutElement layoutElement;

    [SerializeField] private int maxCharacter;

    void Update()
    {
        int headerLength = headerField.text.Length;
        int contentLength = contentField.text.Length;

        layoutElement.enabled = (headerLength > maxCharacter || contentLength > maxCharacter) ? true : false;
    }
}
