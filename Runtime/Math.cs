namespace GameUtils
{
	public static class Math
	{
		public static float Remap(float source, float sourceFrom, float sourceTo, float targetFrom, float targetTo)
		{
			return targetFrom + (source-sourceFrom)*(targetTo-targetFrom)/(sourceTo-sourceFrom);
		}
		
	}
}