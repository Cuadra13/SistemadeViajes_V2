namespace SistemadeViajes_V2.Entidades
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int idcolaborador { get; set; }
        public colaborador colaborador { get; set; }
    }
}

