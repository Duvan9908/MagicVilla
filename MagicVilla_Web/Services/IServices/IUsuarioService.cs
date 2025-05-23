﻿using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web.Services.IServices
{
    public interface IUsuarioService
    {
        Task<T> Login<T>(LoginRequestDTO dto);
        Task<T> Registrar<T>(RegistroRequestDTO dto);
    }
}
