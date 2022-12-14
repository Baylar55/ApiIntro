using Business.DTOs.Department.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validators.Department;
public class DepartmentCreateDTOValidator : AbstractValidator<DepartmentCreateDTO>
{
	public DepartmentCreateDTOValidator()
	{
		RuleFor(d => d.Title)
			   .MinimumLength(3)
			   .WithMessage("Minimum title length must be 3");
	}
    
}
