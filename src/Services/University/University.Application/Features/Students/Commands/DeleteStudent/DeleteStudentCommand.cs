﻿using MediatR;

namespace University.Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentCommand : IRequest
{
    public int StudentId { get; set; }
}
