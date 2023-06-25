using MedicalBotTask.Domain;

Console.WriteLine($"Hi, I'm {MedicalBot.GetBotName()}. I'm here to help you in your medication.");
Console.WriteLine("Enter your (patient) details:");
Console.WriteLine("Enter Patient Name:");

var patient = new Patient();

var input = Console.ReadLine();

while (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Try again!");
    input = Console.ReadLine();
}

while (!patient.SetName(input, out var error))
{
    Console.WriteLine(error);
    input = Console.ReadLine();
}

Console.WriteLine("Enter Patient Age:");

input = Console.ReadLine();

while (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Try again!");
    input = Console.ReadLine();
}

while (!int.TryParse(input, out _))
{
    Console.WriteLine("Incorrect input. Try again.");
    input = Console.ReadLine();
}

while (!patient.SetAge(int.Parse(input), out var error))
{
    Console.WriteLine(error);
    input = Console.ReadLine();
}

Console.WriteLine("Enter Patient Gender:");

input = Console.ReadLine();

while (string.IsNullOrWhiteSpace(input))
{
    Console.WriteLine("Try again!");
    input = Console.ReadLine();
}

while (!patient.SetGender(input, out var error))
{
    Console.WriteLine(error);
    input = Console.ReadLine();
}

Console.WriteLine("Enter Medical History.:");

input = Console.ReadLine();

if (input != null)
{
    patient.SetMedicalHistory(input);
}


Console.WriteLine($"Welcome, {patient.GetName()}, 15.");
Console.WriteLine("Which of the following symptoms do you have:");

Console.WriteLine("S1. Headache");
Console.WriteLine("S2. Skin rashes");
Console.WriteLine("S3. Dizziness");

Console.WriteLine("Enter the symptom code from above list (S1, S2 or S3):");

input = Console.ReadLine();

while (string.IsNullOrEmpty(input))
{
    Console.WriteLine("Incorrect input");
    input = Console.ReadLine();
}

patient.SetSymptomCode(input);

Console.WriteLine("Your prescription based on your age, symptoms and medical history:");

MedicalBot.PrescribeMedication(patient);

Console.WriteLine(patient.GetPrescription());