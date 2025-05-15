using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryCanvas : MonoBehaviour
{
    [SerializeField] Image Hero;
    [SerializeField] Image HeroFace;
    [SerializeField] Image Other;
    [SerializeField] Image OtherFace;
    [SerializeField] GameObject Dialog;
    [SerializeField] TextMeshProUGUI DialogText;
    [SerializeField] Button NextButton;
    [SerializeField] Image Frontground;
    [SerializeField] Image Background;
    [SerializeField] Image Loading;

    /// <summary>
    /// �_�C�A���O��SetActive(true)����֐�
    /// </summary>
    public void OpenDialog()
    {

    }
    /// <summary>
    /// �_�C�A���O��SetActive(false)����֐�
    /// </summary>
    public void CloseDialog() 
    { 
    
    }
    /// <summary>
    /// �_�C�A���O��Text������������֐�
    /// </summary>
    public void UpdateDialog()
    {
        
    }
    /// <summary>
    /// Hero��SetActive(true)����֐�
    /// </summary>
    public void OpenHero()
    {

    }
    /// <summary>
    /// Hero��SetActive(false)����֐�
    /// </summary>
    public void CloseHero()
    {

    }
    /// <summary>
    /// �L�����摜���Z�b�g����B�獷���̈ʒu�����肷��
    /// </summary>
    /// <param name="sprite">�L�����C���X�g</param>
    /// <param name="facePoints">����W</param>
    public void SetHero(Sprite sprite, Vector2 facePoints)
    {
        //�L�����摜��ݒ肷��
        //image.gameobject.transform.localPositon��ύX����
    }
    /// <summary>
    /// Hero�̊�C���X�g�ύX����֐�
    /// </summary>
    /// <param name="sprite">��C���X�g</param>
    public void SetHeroFace(Sprite sprite)
    {
        //�L������摜��ݒ肷��
    }
    /// <summary>
    /// Other��SetActive(true)����֐�		
    /// </summary>
    public void OpenOther()
    {

    }
    /// <summary>
    /// Other��SetActive(false)����֐�		
    /// </summary>
    public void CloseOther()
    {

    }
    /// <summary>
    /// Hero�̃C���X�g�ύX����֐�
    /// </summary>
    public void SetOther()
    {

    }
    /// <summary>
    /// Other�̊�C���X�g�ύX����֐�
    /// </summary>
    public void SetOtherFace()
    {

    }
    /// <summary>
    /// �w�i��ύX����֐�
    /// </summary>
    public void ChangeBackGround()
    {
        //����͓������̂�\��
    }
    /// <summary>
    /// Loading��SetActive(true)����֐�		
    /// </summary>
    public void OpenLoading()
    {

    }
    /// <summary>
    /// Loading��SetActive(false)����֐�		
    /// </summary>
    public void CloseLoading()
    { 

    }

    //�ȉ��쐬���Ȃ��Ă�������
    public void StartAttentionHero()
    {
        Hero.color = Color.white;
        HeroFace.color = Color.white;
    }

    public void StopAttentionHero()
    {
        Hero.color = Color.gray;
        HeroFace.color = Color.gray;
    }

    public void StartAttentionOther()
    {
        Other.color = Color.white;
        OtherFace.color = Color.white;
    }

    public void StopAttentionOther()
    {
        Other.color = Color.gray;
        OtherFace.color = Color.gray;
    }
}
