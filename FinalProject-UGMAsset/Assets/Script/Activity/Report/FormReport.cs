using System;
using UnityEngine;
using UnityEngine.UI;
using TMPRo;

public class FormReport : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tbTitle;
    [SerializeField] private TextMeshProUGUI tbDescription;
    [SerializeField] private Dropdown dropdownType;
    private string typeSelected;
    void Start()
    {
        dropdownType.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    private void OnDropdownValueChanged(int index)
    {
        this.typeSelected = dropdownType.options[index].text;
    }

    private string getID()
    {
        return "";
    }

    private string getUserID()
    {
        return "";
    }

    private string getReporter()
    {
        string ID = getID();
        return "";
    }

    private ReportTypes.ReportType getType()
    {
        ReportTypes.ReportType selected = ReportTypes.ReportType.TypeA;
        return selected;
    }

    private string getImageURL()
    {
        return "";
    }

    public void SubmitReport()
    {
        Report newReport = new Report
        {
            Id = getID(),
            UserID = getUserID(),
            Title = tbTitle.text,
            Reporter = getReporter(),
            Type = getType(),
            ImageURL = getImageURL(),
            Description = tbDescription.text,
            CreatedAt = DateTime.Now.ToString("M/d/yyyy")
        }
    }
}