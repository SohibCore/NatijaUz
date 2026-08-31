using MediatR;
using NatijaUz.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using NatijaUz.Infrastructure.Persistence;
using NatijaUz.Application.Auth.Services.RegisterService.Interfaces;
using NatijaUz.Application.Auth.Services.RegisterService.Commands.Dtos;
using NatijaUz.Application.Auth.Services.RegisterService.Commands.Register;

public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterDto>
{
    private readonly AppDbContext _context;
    private readonly IEmailSender _emailSender;
    public RegisterHandler(AppDbContext context, IEmailSender emailSender)
    {
        _context = context;
        _emailSender = emailSender;
    }

    public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellation)
    {
        var emailExists = await _context.Users.AnyAsync(u => u.Email == request.dto.Email, cancellation);

        if (emailExists)
            throw new Exception("Bu email allaqachon ro'yxatdan o'tgan");

        var code = new Random().Next(100000, 999999).ToString();

        var pending = await _context.PendingRegistrations
            .SingleOrDefaultAsync(p => p.Email == request.dto.Email, cancellation);

        if (pending is not null)
        {
            pending.Password = BCrypt.Net.BCrypt.HashPassword(request.dto.Password);
            pending.FullName = request.dto.FullName;
            pending.Pinfl = request.dto.Pinfl;
            pending.PhoneNumber = request.dto.PhoneNumber;
            pending.Address = request.dto.Address;
            pending.DateOfBirth = request.dto.DateOfBirth;
            pending.UserName = request.dto.UserName;
            pending.Code = code;
            pending.ExpiresAt = DateTime.UtcNow.AddMinutes(3);
            pending.AttemptCount = 0;
        }
        else
        {
            pending = new PendingRegistration
            {
                Password = BCrypt.Net.BCrypt.HashPassword(request.dto.Password),
                FullName = request.dto.FullName,
                Pinfl = request.dto.Pinfl,
                PhoneNumber = request.dto.PhoneNumber,
                Address = request.dto.Address,
                DateOfBirth = request.dto.DateOfBirth,
                UserName = request.dto.UserName,
                Email = request.dto.Email,
                Code = code,
                ExpiresAt = DateTime.UtcNow.AddMinutes(3),
                AttemptCount = 0,
            };
            _context.PendingRegistrations.Add(pending);
        }

        await _context.SaveChangesAsync(cancellation);

        await _emailSender.SendAsync(request.dto.Email, "Tasdiqlash kodi",
            $"Sizning tasdiqlash kodingiz: {code}");

        return new RegisterDto
        {
            FullName = pending.FullName,
            Address = pending.Address,
            Pinfl = pending.Pinfl,
            PhoneNumber = pending.PhoneNumber,
            DateOfBirth = pending.DateOfBirth,
            Email = pending.Email,
            UserName = pending.UserName
        };
    }
}