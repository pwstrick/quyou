//=========================================
//
// �� �ߣ�ũ�񲮲�
// �� �䣺over140@gmail.com
// �� �ͣ�http://over140.cnblogs.com/
// ʱ �䣺2009-2-26 11:19:44
// �� ������֤�������ڶ�Model��ֵ��ʱ�������֤��
//
//=========================================

using System;
using System.Collections.Generic;
using System.Text;

namespace Lasy.Validator
{
    /// <summary>
    /// ������֤�����ڶ�Model��ֵ��ʱ�������֤��
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// ������֤
        /// </summary>
        /// <param name="value">Ҫ��֤������</param>
        /// <returns></returns>
        bool IsValid(object value);

        /// <summary>
        /// �ֶ����ƣ�Ĭ��������
        /// </summary>
        string Key { get; set; }

        /// <summary>
        /// �Ƿ���Ҫ��������������Ϣƴ��
        /// </summary>
        //bool SetFailMessageParams { get; set; }

        /// <summary>
        /// ��֤ʧ�ܺ��ֶ�˵��
        /// </summary>
        string FailKeyDesc { get; set; }

        /// <summary>
        /// ��֤ʧ�ܺ���ʾ�Ĵ�����Ϣ
        /// </summary>
        string FailMessage { get; set; }

        /// <summary>
        /// ��֤ʧ�ܺ����õ�ֵ
        /// </summary>
        object FailDefaultValue { get; set; }

        /// <summary>
        /// �������ʧ����Ϣָ��format��value����
        /// </summary>
        /// <returns></returns>
        object[] GetFailFormatValues();

    }
}

///// <summary>
///// �Ƿ����Դ�ļ���ȡ[��ʱδ��]
///// </summary>
////bool resouce { get; }
//"mask" : "{0}������������ʽ[{1}]",   
//"creditCard" : "{0}����һ���Ϸ������ÿ���",   
//"email" : "{0}����һ���Ϸ���Email��ַ",   
//"intRange" : "{0}����{1}��{2}֮��",   
//"floatRange" : "{0}����{1}��{2}֮��",   
//"maxLength" : "{0}�ĳ��ȴ���{1}",   
//"minLength" : "{0}�ĳ���С��{1}",   
//"required" : "{0}����Ϊ��",   

//errors.required={0} is required.

//errors.minlength={0} cannot be less than {1} characters.

//errors.maxlength={0} cannot be greater than {2} characters.

//errors.invalid={0} is invalid.

//errors.byte={0} must be an byte.

//errors.short={0} must be an short.

//errors.integer={0} must be an integer.

//errors.long={0} must be an long.

//errors.float={0} must be an float.

//errors.double={0} must be an double.

//errors.date={0} is not a date.

//errors.range={0} is not in the range {1} through {2}.

//errors.creditcard={0} is not a valid credit card number.

//errors.email={0} is an invalid e-mail address.
