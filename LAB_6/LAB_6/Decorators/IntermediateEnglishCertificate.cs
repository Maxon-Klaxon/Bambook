using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_6.Domain;

namespace LAB_6.Decorators
{
    public class IntermediateEnglishCertificate : EmployeeDecorator
    {
        private string _title;
        private int _year;

        public IntermediateEnglishCertificate(Employee employee, string title, int year)
            : base(employee)
        {
            _title = title;
            _year = year;
        }

        public override string GetInfo()
        {
            // ьерем инфу от предыдущего слоя и добавляем свое
            return $"{base.GetInfo()}\n - Сертификат английского: {_title} ({_year})";
        }
    }
}
