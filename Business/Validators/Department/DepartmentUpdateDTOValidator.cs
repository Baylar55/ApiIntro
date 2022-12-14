using Business.DTOs.Department.Request;
using FluentValidation;


namespace Business.Validators.Department; 
public class DepartmentUpdateDTOValidator : AbstractValidator<DepartmentUpdateDTO>
{
	public DepartmentUpdateDTOValidator()
	{
		RuleFor(d => d.Title)
			   .MinimumLength(3)
			   .WithMessage("Minimum title length must be 3");
	}

}
