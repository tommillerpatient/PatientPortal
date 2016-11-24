using System.ComponentModel.DataAnnotations;

namespace PatientApi.PlatformClients.Enums
{
	public enum CPT
	{
		[Display(Name = "Gastric Bypass/Roux y")]
		GastricBypassRouxy = 43644,

		[Display(Name = "Gastric Banding")]
		GastricBanding = 43770,


		[Display(Name = "Gastric Sleeve")] 
		GastricSleeve = 43775,

		[Display(Name = "EGD")] 
		EGD = 43235,

		[Display(Name = "EGD w/Biopsy")] 
		EGDWithBiopsy = 43239,

		[Display(Name = "Revision")] 
		Revision = 43848,

		[Display(Name = "Psych Eval")] 
		PsychEval = 90791,

		[Display(Name = "Individual Psychotherapy")] 
		IndividualPsychotherapy = 90832,

		[Display(Name = "MH Follow up 60 min")] 
		MHFollowup60Min = 90837,

		[Display(Name = "Nutritional Therapy individual 15 minutes")] 
		NutritionalTherapyIndividual15Minutes = 97802,


		[Display(Name = "Nutritional Therapy re-assessment 15 minutes")] 
		NutritionalTherapyReassessment15Minutes = 97803,

		[Display(Name = "Nutritional Therapy group 30 minutes")] 
		NutritionalTherapygroup30Minutes = 97804,

        //Orthopedic
        [Display(Name = "New Office Visit")] 
        NewOfficeVisit = 99202,

        [Display(Name = "Established Office Visit")]
        EstablishedOfficeVisit = 99212,

        [Display(Name = "Post-op Visit")]
        PostOpVisit = 99024,

        [Display(Name = "Injection - Tendon Sheath")]
        InjectionsTendonSheath = 20550,

        [Display(Name = "Injection - Tendon Origin")]
        InjectionsTendonOrigin = 20551,

        [Display(Name = "Injection - Trigger Point [1-2]")]
        InjectionsTriggerpoint1_2 = 20552,

        [Display(Name = "Injection - Trigger Point [3+]")]
        InjectionsTriggerpoint3 = 20553,

        [Display(Name = "Injection - Small Joint/Bursa US")]
        InjectionsSmallJointBursaUS = 20604,

        [Display(Name = "Injection - Medium Joint/Bursa")]
        InjectionsMediumJointBursa = 20605,

        [Display(Name = "Injection - Medium with US")]
        InjectionsMediumUS = 20606,

        [Display(Name = "Injection - Major Joint")]
        InjectionsMajorJoint = 20610,

        [Display(Name = "Injection - Major Joint with US")]
        InjectionsMajorJointUS = 20611,

        [Display(Name = "Injection - Fluro evaluation")]
        InjectionsFloroEvaluation = 76000,

        [Display(Name = "Injection - Fluro guided joint")]
        InjectionsFloroGuidedJoint = 77002,

        [Display(Name = "Injection - Fluro spine")]
        InjectionsFloroSpine = 77003,

        [Display(Name = "Injection - Fluro joint survey 1V")]
        InjectionsFloroJointSurvey1V = 77077,

        [Display(Name = "Injection - Fluro stress or Contralat")]
        InjectionsFloroStress = 77071,

        [Display(Name = "Injection - Ultrasound extremity")]
        InjectionsUSExtremity = 76881,

        [Display(Name = "Injection - Ultrasound extremity LIM")]
        InjectionsUSExtremityLIM = 76882,

        [Display(Name = "Injection - Ultrasound guided")]
        InjectionsGuided = 76942,

        [Display(Name = "Injection - Orthoscan shoulder")]
        InjectionsOrthoscanShoulder = 73040,

        [Display(Name = "Injection - Orthoscan Elbow")]
        InjectionsOrthoscanElbow = 73085,

        [Display(Name = "Injection - Orthoscan Wrist")]
        InjectionsOrthoscanWrist = 73115,

        [Display(Name = "Injection - Orthoscan Knee")]
        InjectionsOrthoscanKnee = 73580,

        [Display(Name = "Injection - Orthoscan Ankle")]
        InjectionsOrthoscanAnkle = 73615,

        [Display(Name = "Injection - Suprascapular Block")]
        InjectionsSuprascapularBlock = 64418,

        [Display(Name = "X-Rays - 2v Shoulder")]
        XRay2vShoulder = 73030,

        [Display(Name = "X-Rays - AC Joint")]
        XRayACJoint = 73050,

        [Display(Name = "X-Rays - Clavicle")]
        XRayClavicle = 73000,

        [Display(Name = "X-Rays - Humerus")]
        XRayHumerus = 73060,

        [Display(Name = "X-Rays - 3V Elbow")]
        XRay3VElbow = 73070,

        [Display(Name = "X-Rays - Pelvis/B Hip")]
        XRayPelvis = 73520,

        [Display(Name = "X-Rays - 2V Femur")]
        XRay2VFemur = 73550,

        [Display(Name = "X-Rays - 2V Knee")]
        XRay2VKnee = 73654,

        [Display(Name = "X-Rays - 4V Knee")]
        XRay4VKnee = 73564,

        [Display(Name = "X-Rays - 4V Tibia")]
        XRay4VTibia = 73590
	}
}
