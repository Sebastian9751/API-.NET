using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string Lastname { get; set; }
        [StringLength(15)]
        public string CURP { get; set; }
        [StringLength(13)]
        public string RFC { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(80)]
        public string Password { get; set; }

        public void SetPassword(string password)
        {
            Password = PasswordHelper.HashPassword(password);
        }

        public bool VerifyPassword(string password)
        {
            return PasswordHelper.VerifyPassword(password, Password);
        }
    }
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                string hash = Convert.ToBase64String(hashedBytes);
                Console.WriteLine(hash);
                return hash;
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }
}
