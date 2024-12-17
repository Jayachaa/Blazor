export function afterWebStarted(blazor)
{
    blazor.registerCustomEventType('FKeyCustomEvent', {
        browserEventName: 'resolveFkey',
        createEventArgs: eventArgsCreator
    });
}
function eventArgsCreator(event)
{
    return {
        SearchText: event.target.value,
    };
}