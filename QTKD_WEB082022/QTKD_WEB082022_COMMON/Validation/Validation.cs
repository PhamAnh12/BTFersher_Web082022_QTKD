﻿using Misa.Web082022.QTKD.Common.Attributes;
using MISA.Web082022.QTKD.Common.Entities;

namespace Misa.Web082022.QTKD.Common.Validation
{
    /// <summary>
    /// Validate dữ liệu
    ///  CreatedBy PCTUANANH(25/09/2022)
   /// </summary>
    public class Validation
    {
        public static List<string> Validate(Employee employee)
        {

            //validate dữ liệu
            var props = typeof(Employee).GetProperties(); //lấy các prop của Employee
            var ValidateErrors = new List<string>(); //danh sách lỗi
            foreach (var prop in props)
            {
                var propName = prop.Name; //lấy tên của prop
                var propValue = prop.GetValue(employee); // lấy giá trị
                                                         //lấy attribute của prop
                                                         //nếu prop có attribute IsNotNullOrEmptyAttribute thì trả về đối tượng attribute
                                                         // nếu không trả về null
                var isNotNullOrEmpty = (IsNotNullOrEmptyAttribute?)Attribute.GetCustomAttribute(prop, typeof(IsNotNullOrEmptyAttribute));
                //nếu có chứa attr và giá trị attr không trống
                if (isNotNullOrEmpty != null && string.IsNullOrEmpty(propValue?.ToString()))
                {
                    ValidateErrors.Add(isNotNullOrEmpty.Msg);
                }
            }
            return ValidateErrors;

        }
    }
}