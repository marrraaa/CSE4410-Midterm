/*using system.collections;
using system.collections.generic;
using unityengine;
using unityengine.uielements;

public class mainmenuevents : monobehaviour
{
    private uidocument _document;

    private button _button;

    private list<button> _menubuttons = new list<button>();

    private audiosource _audiosource;

    private void awake()
    {
        _audiosource = getcomponent<audiosource>();
        _document = getcomponent<uidocument>();

        _button = _document.rootvisualelement.q("startgamebutton") as button;
        _button.registercallback<clickevent>(onplaygameclick);

        _menubuttons = _document.rootvisualelement.query<button>().tolist();
        for (int i = 0; i < _menubuttons.count; i++)
        {
            _menubuttons[i].registercallback<clickevent>(onallbuttonsclick);
        }
    }

    private void ondisable()
    {
        _button.unregistercallback<clickevent>(onplaygameclick);

        for (int i = 0; i < _menubuttons.count; i++)
        {
            _menubuttons[i].unregistercallback<clickevent>(onallbuttonsclick);
        }
    }

    private void onplaygameclick(clickevent evt)
    {
        debug.log("the start button has been pressed.");
    }

    private void onallbuttonsclick(clickevent evt)
    {
        _audiosource.play();
    }
}
*/