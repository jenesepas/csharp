using System;

namespace Project1
{
	public partial class ventana : Gtk.Window
	{
		public ventana () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
		}
	}
}

