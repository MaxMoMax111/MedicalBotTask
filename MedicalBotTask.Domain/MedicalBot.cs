using System.Data.SqlTypes;

namespace MedicalBotTask.Domain;

public static class MedicalBot
{
    private const string BotName = "Bob";

    public static readonly Dictionary<string, string> Symptoms = new()
        {{"s1", "Headache"}, {"s2", "Skin rashes"}, {"s3", "Dizziness"}};

    public static string GetBotName()
    {
        return BotName;
    }

    public static void PrescribeMedication(Patient patient)
    {
        var symptomCode = patient.GetSymptomCode();

        if (symptomCode is null) return;

        patient.SetPrescription(GetMedicine(patient, symptomCode));
    }

    private static string GetDosage(string medicineName, int age)
    {
        return (medicineName, age) switch
        {
            ("Ibuprofen", < 18) => "The dosage is 400 mg",
            ("Ibuprofen", > 18) => "The dosage is 800 mg",
            ("Diphenhydramine", < 18) => "The dosage is 30 mg",
            ("Diphenhydramine", > 18) => "The the dosage is 300 mg",
            ("Dimenhydrinate", < 18) => "The the dosage is 30 mg",
            ("Dimenhydrinate", > 18) => "The the dosage is 400 mg",
            ("Metformin", _) => "The the dosage is 30 mg",
            _ => "Unknown dosage."
        };
    }

    private static string GetMedicine(Patient patient, string symptomCode)
    {
        switch (symptomCode)
        {
            case "s1":
            {
                const string medical = "Ibuprofen";

                return $"{medical}. {GetDosage(medical, patient.GetAge())}";
                }

            case "s2":
            {
                const string medical = "Diphenhydramine";

                return $"{medical}. {GetDosage(medical, patient.GetAge())}";
            }

            case "s3":
            {
                if (CheckDiabetes(patient))
                {
                    const string medicalIfDiabetes = "Metformin";

                    return $"{medicalIfDiabetes}. {GetDosage(medicalIfDiabetes, patient.GetAge())}";
                }

                const string medical = "Dimenhydrinate";

                    return $"{medical}. {GetDosage(medical, patient.GetAge())}";
                }
        }

        return "The patient has unknown symptoms";
    }

    private static bool CheckDiabetes(Patient patient)
    {
        var medicalHistory = patient.GetMedicalHistory();

        if (medicalHistory == null)
        {
            return false;
        }

        return medicalHistory?.IndexOf("diabetes", StringComparison.OrdinalIgnoreCase) > -1;
    }
}