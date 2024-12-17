using Microsoft.AspNetCore.Components;

namespace BlazorErrorBoundary
{
	[EventHandler("onFKeyCustomEvent", typeof(FKeyEventArgs),
	              enableStopPropagation: true, enablePreventDefault: true)]
	public static class EventHandlers
	{
	}
}
