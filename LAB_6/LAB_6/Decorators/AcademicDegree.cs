using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_6.Domain;

namespace LAB_6.Decorators
{
    public class AcademicDegree : EmployeeDecorator
    {
        private string _degreeTitle;
        private string _scienceArea;

        public AcademicDegree(Employee employee, string degreeTitle, string scienceArea)
            : base(employee)
        {
            _degreeTitle = degreeTitle;
            _scienceArea = scienceArea;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()}\n - Ученая степень: {_degreeTitle} в области {_scienceArea}";
        }
    }
}
