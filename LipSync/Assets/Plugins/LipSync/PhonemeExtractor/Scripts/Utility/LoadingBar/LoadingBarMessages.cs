namespace VisemeExtractor
{
    public class LoadingBarMessages
    {
        private static string phase_01 = "Extracting phonemes from audio file";
        private static string phase_02 = "Optimizing phonetic representation";
        private static string phase_03 = "Generating visemes";
        private static string phase_04 = "Generating animation sequence";
        private static string phase_05 = "Completed";

        public static string[] GetAllPhaseNames()
        {
            return new string[] { phase_01, phase_02, phase_03, phase_04, phase_05 };
        }
    }
}
