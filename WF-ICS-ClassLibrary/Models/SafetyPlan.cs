using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ICS_ClassLibrary.Models
{
    [ProtoContract]
    [Serializable]
    public class SafetyPlan :  ICloneable
    {
        public SafetyPlan()
        {
            SafetyPlanTemplateID = System.Guid.NewGuid(); additionalPPE = new List<string>(); checkedFieldNames = new List<string>();
            PlanID = System.Guid.NewGuid(); additionalPPE = new List<string>(); checkedFieldNames = new List<string>();
        }

        [ProtoMember(1)] private Guid _SafetyPlanTemplateID;
        [ProtoMember(2)] private string _HazardName;
        [ProtoMember(3)] private string _Description;
        [ProtoMember(4)] private string _Precautions;
        [ProtoMember(5)] private string _SpecialInstructions;
        [ProtoMember(6)] private List<string> _additionalPPE;
        [ProtoMember(7)] private List<string> _checkedFieldNames;
        [ProtoMember(8)] private bool _isUniversal;
        [ProtoMember(9)] private DateTime _LastUpdatedUTC;
        [ProtoMember(10)] private bool _active;
        [ProtoMember(11)] private Guid _OrganizationID;

        [ProtoMember(12)] private Guid _PlanID;
        [ProtoMember(13)] private string _TaskNumber;
        [ProtoMember(14)] private string _TaskName;
        [ProtoMember(15)] private string _TeamName;
        [ProtoMember(16)] private int _OpPeriod;
        [ProtoMember(17)] private DateTime _DatePrepared;
        [ProtoMember(18)] private string _PreparedBy;
        [ProtoMember(19)] private int _HazardNumber;
        [ProtoMember(20)] private Guid _TaskID;

      




        public Guid SafetyPlanTemplateID { get => _SafetyPlanTemplateID; set => _SafetyPlanTemplateID = value; }
        public string HazardName { get => _HazardName; set => _HazardName = value; }
        public string Description { get => _Description; set => _Description = value; }
        public string Precautions { get => _Precautions; set => _Precautions = value; }
        public string SpecialInstructions { get => _SpecialInstructions; set => _SpecialInstructions = value; }
        public List<string> additionalPPE { get => _additionalPPE; set => _additionalPPE = value; }
        public List<string> checkedFieldNames { get => _checkedFieldNames; set => _checkedFieldNames = value; }
        public bool isUniversal { get => _isUniversal; set => _isUniversal = value; }
        public DateTime LastUpdatedUTC { get => _LastUpdatedUTC; set => _LastUpdatedUTC = value; }


        public string additionalPPECSV
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in additionalPPE)
                {
                    if (sb.Length > 0) { sb.Append(";"); }
                    sb.Append(s);
                }
                return sb.ToString();
            }
        }
        public string checkedFieldNamesCSV
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (string s in checkedFieldNames)
                {
                    if (sb.Length > 0) { sb.Append(";"); }
                    sb.Append(s);
                }
                return sb.ToString();
            }
        }

        public bool Active { get { return _active; } set { _active = value; } }
        public Guid OrganizationID { get => _OrganizationID; set => _OrganizationID = value; }


        public Guid PlanID { get => _PlanID; set => _PlanID = value; }
        public string TaskNumber { get => _TaskNumber; set => _TaskNumber = value; }
        public string TaskName { get => _TaskName; set => _TaskName = value; }
        public string TeamName { get => _TeamName; set => _TeamName = value; }
        public int OpPeriod { get => _OpPeriod; set => _OpPeriod = value; }
        public DateTime DatePrepared { get => _DatePrepared; set => _DatePrepared = value; }
        public string PreparedBy { get => _PreparedBy; set => _PreparedBy = value; }
        public int HazardNumber { get => _HazardNumber; set => _HazardNumber = value; }
        public Guid TaskID { get => _TaskID; set => _TaskID = value; }


        public SafetyPlan generateDuplciateSafetyPlan()
        {
            SafetyPlan newPlan = new SafetyPlan();
            newPlan.PlanID = Guid.NewGuid();
            newPlan.TaskName = TaskName;
            newPlan.TaskNumber = TaskNumber;

            newPlan.TaskID = TaskID;
            newPlan.PreparedBy = PreparedBy;
            newPlan.HazardNumber = HazardNumber;
            newPlan.HazardName = HazardName;
            newPlan.Description = Description;
            newPlan.Precautions = Precautions;
            newPlan.SpecialInstructions = SpecialInstructions;
            newPlan.additionalPPE = additionalPPE;
            newPlan.checkedFieldNames = checkedFieldNames;
            return newPlan;

        }


        public string PPEAsString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                List<SafetyPlanCheckbox> checkboxes = new SafetyPlanCheckbox().getCheckboxes();
                List<int> usedCustomPPEFields = new List<int>();

                foreach (string s in checkedFieldNames)
                {
                    if (!string.IsNullOrEmpty(s) && checkboxes.Any(o => o.FieldName.Equals(s, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        SafetyPlanCheckbox cb = checkboxes.First(o => o.FieldName.Equals(s, StringComparison.InvariantCultureIgnoreCase));
                        if (!string.IsNullOrEmpty(cb.FieldText))
                        {
                            if (sb.Length > 0) { sb.Append(", "); }
                            sb.Append(cb.FieldText);
                        }
                        else
                        {
                            switch (cb.FreeTextFieldName)
                            {
                                case "Text25":
                                    if (!string.IsNullOrEmpty(additionalPPE[0]))
                                    {
                                        if (sb.Length > 0) { sb.Append(", "); }
                                        sb.Append(additionalPPE[0]);
                                    }
                                    break;


                                case "Text28":
                                    if (!string.IsNullOrEmpty(additionalPPE[1]))
                                    {
                                        if (sb.Length > 0) { sb.Append(", "); }
                                        sb.Append(additionalPPE[1]);
                                    }
                                    break;

                                case "Text29":
                                    if (!string.IsNullOrEmpty(additionalPPE[2]))
                                    {
                                        if (sb.Length > 0) { sb.Append(", "); }
                                        sb.Append(additionalPPE[2]);
                                    }
                                    break;

                                case "Text30":
                                    if (!string.IsNullOrEmpty(additionalPPE[3]))
                                    {
                                        if (sb.Length > 0) { sb.Append(", "); }
                                        sb.Append(additionalPPE[3]);
                                    }
                                    break;

                                case "Text31":
                                    if (!string.IsNullOrEmpty(additionalPPE[4]))
                                    {
                                        if (sb.Length > 0) { sb.Append(", "); }
                                        sb.Append(additionalPPE[4]);
                                    }
                                    break;

                                case "Text32":
                                    if (!string.IsNullOrEmpty(additionalPPE[5]))
                                    {
                                        if (sb.Length > 0) { sb.Append(", "); }
                                        sb.Append(additionalPPE[5]);
                                    }
                                    break;
                            }
                        }
                    }
                }

                return sb.ToString();
            }
        }


        public SafetyPlan Clone()
        {
            return this.MemberwiseClone() as SafetyPlan;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }



    }

    public class SafetyPlanCheckbox
    {
        public string FieldName { get; set; }
        public string ControlName { get { return FieldName.Replace(" ", ""); } }
        public string FieldText { get; set; }
        public string FreeTextFieldName { get; set; }
        public bool HasFreeText { get => !string.IsNullOrEmpty(FreeTextFieldName); }

        public int Column { get; set; }

        public SafetyPlanCheckbox() { }
        public SafetyPlanCheckbox(string fieldname, string fieldtext, int column, string freetextfieldname = null)
        {
            FieldName = fieldname;
            FieldText = fieldtext;
            Column = column;
            FreeTextFieldName = freetextfieldname;
        }

        public List<SafetyPlanCheckbox> getCheckboxes()
        {
            List<SafetyPlanCheckbox> allCheckboxes = new List<SafetyPlanCheckbox>();

            allCheckboxes = new List<SafetyPlanCheckbox>();

            //column 1
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box1", "Work Gloves", 1));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box2", "Latex Gloves", 1));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box3", "Goggles", 1));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box4", "Particle Mask", 1));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box5", "Whitewater Helmet", 1));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box6", "Whitewater PFD", 1));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box7", "Throw Bag(s)", 1));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box8", "", 1, "Text25"));

            //column 2
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box16", "Climbing Helmet", 2));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box15", "Access Rope(s)", 2));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box14", "Edge Ropes", 2));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box13", "Seat & Chest Harness", 2));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box12", "", 2, "Text28"));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box11", "PFD", 2));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box10", "Floater Suit", 2));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box9", "", 2, "Text29"));

            //column 3
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box17", "Avalanche Beacon", 3));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box18", "Avalanche Probe", 3));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box19", "Avalanche Shovel", 3));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box20", "Wands", 3));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box21", "", 3, "Text30"));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box22", "", 3, "Text31"));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box23", "", 3, "Text32"));
            allCheckboxes.Add(new SafetyPlanCheckbox("Check Box24", "Glow Sticks", 3));

            return allCheckboxes;

        }
    }
}
