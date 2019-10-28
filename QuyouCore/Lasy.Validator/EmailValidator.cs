//=========================================
//
// �� �ߣ�ũ�񲮲�
// �� �䣺over140@gmail.com
// �� �ͣ�http://over140.cnblogs.com/
// ʱ �䣺2009-2-20 22:19:12
// �� ����EMail��֤��
//
//=========================================

using System;
using Lasy.Utility;

namespace Lasy.Validator
{

    /// <summary>
    /// EMail��֤��
    /// </summary>
    public sealed class EmailAttribute : BaseValidatorAttribute
    {
        #region Constructors

        /// <summary>
        /// ���캯��
        /// </summary>
        public EmailAttribute() 
        {
            this.FailMessage = "{0}����һ���Ϸ���Email��ַ";
            this.FailDefaultValue = string.Empty;
        }

        #endregion

        #region Method

        /// <summary>
        /// ������֤
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            base.Value = value;
            return JudgeUtility.IsEmail(value);
        }

        #endregion

    }
}
