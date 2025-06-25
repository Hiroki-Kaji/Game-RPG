using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StorySystem : MonoBehaviour
{
    [SerializeField] StoryCanvas _storyCanvas;
    [SerializeField] int storyID;
    [SerializeField] Chara chara1;
    [SerializeField] Chara chara2;
    [SerializeField] int speakerID;
    [SerializeField] int textID;
    [SerializeField] bool isSkip;//�X�L�b�v�@�\�̃t���O�H
                                 //true�̎�OpenLoading()���Ăяo���V�[���̐؂�ւ��܂Ŕ�ԁH
                                 //ResourceDataBase�C���X�^���X��
                                 //textData[]����e�L�X�g�����炤
                                 //
                                 //�V�[���؂�ւ��Ŏg������
                                 //OpenLoading()�ǂ��ŌĂяo���H
                                 //CloseDialog()
                                 //CloseHero()
                                 //CloseOther()
                                 //CloseLoading()
    private void Start()
    {
        // �Ƃ肠����false?
        isSkip = false;
        UpdateCharaSprite();
    }
    /// <summary>
    /// StoryCanvas�̕\�����w�����郁�\�b�h
    /// </summary>
    private void UpdateCharaSprite()
    {
        if (_storyCanvas == null) return;
        // �L�����N�^�[1�̕\���Ɛݒ�
        if (chara1 != null)
        {
            _storyCanvas.OpenHero();
            // Chara���痧���G�Ɗ���W��ݒ�
            _storyCanvas.SetHero(chara1.CharaSprite, chara1.FaceCoordinates);
        }
        else
        {
            _storyCanvas.CloseHero();
        }
        // �L�����N�^�[2�̕\���Ɛݒ�
        if (chara2 != null)
        {
            _storyCanvas.OpenOther();
            // Chara���痧���G�Ɗ���W��ݒ�
            //_storyCanvas.SetOther(chara2.CharaSprite, chara2.FaceCoordinates);
        }
        else
        {
            _storyCanvas.CloseOther();
        }
        //�A�N�e�B�u�L�����̐؂�ւ�
        //Hero 1
        //Other 2
        // �b�҂ɒ��ڂ����A�����łȂ����̓O���[�A�E�g����
        if (speakerID == 1)
        {
            _storyCanvas.StartAttentionHero();
            _storyCanvas.StopAttentionOther();
        }
        else if (speakerID == 2)
        {
            _storyCanvas.StartAttentionOther();
            _storyCanvas.StopAttentionHero();
        }
        // Chara�f�[�^��Emotion�ݒ肩��A�\�����ׂ���X�v���C�g���擾����
        Sprite heroFaceSprite = GetSpriteForEmotion(chara1);
        Sprite otherFaceSprite = GetSpriteForEmotion(chara2);
        // StoryCanvas�Ɋ�X�v���C�g�̐ݒ���w��
        _storyCanvas.SetHeroFace(heroFaceSprite);
        //_storyCanvas.SetOtherFace(otherFaceSprite);
        // //chara�Ƃ͊֌W�Ȃ��̂Ń��\�b�h�������������������H
        // // �_�C�A���O�̕\���ƃe�L�X�g�X�V
        // _storyCanvas.OpenDialog();
        // _storyCanvas.UpdateDialog(textID);//�킩��Ȃ��̂łƂ肠���������ɂ��Ă���
        // //�w�i�̍X�V
        // _storyCanvas.ChangeBackGround(storyID);//�킩��Ȃ��̂łƂ肠���������ɂ��Ă���
    }
    private Sprite GetSpriteForEmotion(Chara chara)
    {
        /*if (chara == null) return null;
        switch (chara)
        {
            case Chara.Normal: return chara.Normal;
            case Chara.Angry: return chara.Angry;
            case Chara.Smile: return chara.Smile;
            case Chara.Trouble: return chara.Trouble;
            case Chara.Surprise: return chara.Surprise;
            case Chara.Hurt: return chara.Hurt;
            case Chara.Embarrassing: return chara.Embarrassing;
            case Chara.Agree: return chara.Agree;
            default: return chara.Normal; // �s���ȏꍇ�͒ʏ���Ԃ�
        }*/
        return chara.Normal;
    }
}
