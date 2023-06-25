namespace MedicalBotTask.Domain;

public class Patient
{
    private string? _name;
    private int _age;
    private string? _gender;
    private string? _medicalHistory;
    private string? _symptomCode;
    private string? _prescription;

    public static readonly List<string> Genders = new() { new string("Male"), new string("Female"), new string("Other"), new string("male"), new string("female"), new string("other") };

    public string? GetName()
    {
        return _name;
    }
    
    public bool SetName(string name, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length < 2)
        {
            errorMessage = "Name can not be empty. Minimum length of name is 2 characters. Try again.";
            return false;
        }

        _name = name;
        errorMessage = string.Empty;

        return true;
    }


    public int GetAge()
    {
        return _age;
    }

    public bool SetAge(int age, out string errorMessage)
    {
        switch (age)
        {
            case < 0:
                errorMessage = "Age can not be less then 0. Try again";
                return false;
            case > 100:
                errorMessage = "Age can not be more then 100. Try again";
                return false;
        }

        _age = age;
        errorMessage = string.Empty;

        return true;
    }

    public string? GetGender()
    {
        return _gender;
    }


    public bool SetGender(string gender, out string errorMessage)
    {
        if (!Genders.Exists(g => g == gender))
        {
            errorMessage = "Unknown gender. Try again";
            return false;
        }

        _gender = gender;
        errorMessage = string.Empty;

        return true;
    }

    public string? GetMedicalHistory()
    {
        return _medicalHistory;
    }

    public void SetMedicalHistory(string medicalHistory)
    {
        _medicalHistory = medicalHistory;
    }

    public string? GetSymptomCode()
    {
        return _symptomCode;
    }

    public bool SetSymptomCode(string symptomCode)
    {
        if (MedicalBot.Symptoms.ContainsKey(symptomCode.ToLower()))
        {
            _symptomCode = symptomCode.ToLower();
            return true;
        }

        return false;
    }

    public string? GetSymptomDescription()
    {
        foreach (var symptom in MedicalBot.Symptoms)
        {
            if (_symptomCode != null && _symptomCode.ToLower() == symptom.Key)
            {
                return symptom.Value;
            }
        }

        return "Unknown symptom.";
    }

    public string? GetPrescription()
    {
        return _prescription;
    }

    public void SetPrescription(string prescription)
    {
        _prescription = prescription;
    }
}
