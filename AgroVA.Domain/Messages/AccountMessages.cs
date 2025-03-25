using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroVA.Domain.Messages;

public static class AccountMessages
{
    public const string InvalidEmail = "Email inválido";
    public const string InvalidPassword = "Senha inválida";
    public const string LongEmail = "Email muito longo";
    public const string LongPassword = "Senha muito longa";
    public const string RequiredEmail = "Email é obrigatório";
    public const string RequiredPassword = "Senha é obrigatória";
    public const string WeakPassword = "Senha fraca";
    public const string PasswordsDoNotMatch = "Senhas não conferem";
    public const string UserAlreadyExists = "Usuário já existe";
    public const string UserNotFound = "Usuário não encontrado";
    public const string InvalidLoginAttempt = "Tentativa de login inválida. Usuário ou senha incorreto";
    public const string InvalidRegisterAttempt = "Tentativa de registro inválida";
}
