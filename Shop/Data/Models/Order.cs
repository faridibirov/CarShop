using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models;

public class Order
{
	[BindNever]
	public int Id { get; set; }

	[Display(Name = "Имя")]
	[StringLength(15)]
	[Required(ErrorMessage = "Введите ваше имя")]
	public string Name { get; set; }

	[Display(Name = "Фамилия")]
	[StringLength(15)]
	[Required(ErrorMessage = "Введите вашу фамилию")]
	public string Surname { get; set; }

	[Display(Name = "Адрес")]
	[StringLength(25)]
	[Required(ErrorMessage = "Введите ваш адрес")]
	public string Address { get; set; }

	[Display(Name = "Номер телефона")]
	[StringLength(15)]
	[DataType(DataType.PhoneNumber)]
	[Required(ErrorMessage = "Введите ваш номер телефона")]
	public string Phone { get; set; }

	[Display(Name = "Email")]
	[StringLength(20)]
	[DataType(DataType.EmailAddress)]
	[Required(ErrorMessage = "Введите ваш email")]
	public string Email { get; set; }

	[BindNever]
	[ScaffoldColumn(false)]
	public DateTime Ordertime { get; set; }

	public List<OrderDetail> orderDetails { get; set; }
}