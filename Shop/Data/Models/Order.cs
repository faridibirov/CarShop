using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models;

public class Order
{
	[BindNever]
	public int Id { get; set; }

	[Display(Name = "Имя")]
	[StringLength(15)]
	[Required(ErrorMessage = "Длина имени не менее 2 символов")]
	public string Name { get; set; }

	[Display(Name = "Фамилия")]
	[StringLength(15)]
	[Required(ErrorMessage = "Длина фамилии не менее 2 символов")]
	public string Surname { get; set; }

	[Display(Name = "Адрес")]
	[StringLength(25)]
	[Required(ErrorMessage = "Длина адреса не менее 5 символов")]
	public string Address { get; set; }

	[Display(Name = "Номер телефона")]
	[StringLength(15)]
	[DataType(DataType.PhoneNumber)]
	[Required(ErrorMessage = "Длина номера не менее 10 символов")]
	public string Phone { get; set; }

	[Display(Name = "Email")]
	[StringLength(20)]
	[DataType(DataType.EmailAddress)]
	[Required(ErrorMessage = "Длина email не менее 5 символов")]
	public string Email { get; set; }

	[BindNever]
	[ScaffoldColumn(false)]
	public DateTime Ordertime { get; set; }

	public List<OrderDetail> orderDetails { get; set; }
}