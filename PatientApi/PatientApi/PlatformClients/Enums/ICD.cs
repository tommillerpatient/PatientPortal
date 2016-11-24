using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum ICD
	{
		[Display(Name = "278.00 obesity")] 
		Obesity = 0,

		[Display(Name = "278.01 morbid obesity")] 
		MorbidObesity = 1,

        //Ortho
        [Display(Name = "719.95 Hip FAI")]
        FAI = 2,

        [Display(Name = "719.45 Hip Pain")]
        HipPain = 3,

        [Display(Name = "718.05 Hip Labral Tear")]
        HipLabralTear = 4,

        [Display(Name = "726.5 Hip Greater Trochanteric Bursitis, GM Tear")]
        HipGMlTear = 5,

        [Display(Name = "715.5 Hip Osteoarthritis")]
        HipOsteoarthritis = 6,

        [Display(Name = "718.45 Hip Contracture")]
        HipContracture = 7,

        [Display(Name = "726.5 Hip Illiopsoas tendonitis")]
        HipIlliopsoasTendonitis = 8,

        [Display(Name = "719.41 Shoulder Pain")]
        ShoulderPain = 9,

        [Display(Name = "718.0 Shoulder Chondral Injury")]
        ShoulderChondralInjury = 10,

        [Display(Name = "718.31 Shoulder Anterior Instability")]
        ShoulderAnteriorInstability = 11,

        [Display(Name = "726.0 Shoulder Adhesive Capsulitis")]
        ShoulderAdhesiveCapsulitis = 12,

        [Display(Name = "840.7 Shoulder SLAP Tear")]
        ShoulderSLAPTear = 13,

        [Display(Name = "718.11 Shoulder Loose Body")]
        ShoulderLooseBody = 14,

        [Display(Name = "726.13 / 727.61 Shoulder Rotator Cuff Tear")]
        ShoulderRotatorCuffTear = 15,

        [Display(Name = "726.12 Shoulder Biceps Tenosynovitis")]
        ShoulderBicepsTenosynovitis = 16,

        [Display(Name = "715.11 Shoulder AC joint OA")]
        ShoulderACJointOA = 17,

        [Display(Name = "831.04 Shoulder AC Joint Dislocation")]
        ShoulderACJointDislocation = 18,

        [Display(Name = "717.0 Knee Pain")]
        KneePain = 19,

        [Display(Name = "733.92 Knee Chondral Injury")]
        KneeChondralInjury = 20,

        [Display(Name = "717.7 Knee Chondromalacia Patella")]
        KneeChondromalaciaPatella = 21,

        [Display(Name = "717.6 Knee Loose Body")]
        KneeLooseBody = 22,

        [Display(Name = "732.7 Knee OCD")]
        KneeOCD = 23,

        [Display(Name = "719.46 Knee Patellofemoral Pain")]
        KneePatellofemoralPain = 24,

        [Display(Name = "732.7 Knee Osteonecrosis")]
        KneeOsteonecrosis = 25,

        [Display(Name = "836.0 Knee Meniscal Tear")]
        KneeMeniscalTear = 26,

        [Display(Name = "717.5 Knee Discoid Meniscus")]
        KneeDiscoidMeniscus = 27,

        [Display(Name = "727.83 Knee Plica Syndrome")]
        KneePlicaSyndrome = 28,

        [Display(Name = "718.46 Knee Joint Contracture")]
        KneeJointContracture = 29,

        [Display(Name = "717.83 Knee Old ACL Tear")]
        KneeOldACLTear = 30,

        [Display(Name = "844.2 Knee Cruciate Strain/Sprain")]
        KneeCruciateStrain = 31,

        [Display(Name = "717.84 Knee PCL Tear")]
        KneePCLTear = 32,

        [Display(Name = "844.0 Knee LCL Tear")]
        KneeLCLTear = 33,

        [Display(Name = "844.1 Knee MCL Tear")]
        KneeMCLTear = 33,

        [Display(Name = "836.3 Knee Patellar Instability")]
        KneePatellarInstability = 34,

        [Display(Name = "823.0 Knee Tibial Plateau Fracture")]
        KneeTibiaPlateauFracture = 35,

        [Display(Name = "844.9 Knee Medial Tibial Stress Syndrome")]
        KneeMedialTibialStressSyndrome = 36,

        [Display(Name = "843.8 Knee Quadriceps Tendon Rupture")]
        KneeQuadricepsTendonRupture = 37,

        [Display(Name = "718.05 Knee Hamstring Tendon Rupture")]
        KneeHamstringTendonRupture = 38,

        [Display(Name = "996.4 Knee Retained Hardware")]
        KneeRetainedHardware = 39,

        [Display(Name = "355.8 Knee Neuroma Excision")]
        KneeNeuromaExcision = 40

	}
}
