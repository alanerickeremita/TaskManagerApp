using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TaskManagerApp.View
{
  public class IconLayoutAdapter : BaseAdapter
  {
    private Context activity; //para setar a activity
    private TaskIcon icon;
    private LayoutInflater layoutInflater; //renderizar minha imagem

    public IconLayoutAdapter(TaskIcon _icon, Context _context)
    {
      this.icon = _icon;
      this.activity = _context;
    }

    public override int Count
    {
      get
      {
        return icon.Id;
      }
    }

    public override Java.Lang.Object GetItem(int position)
    {
      return icon.Name;
    }

    public override long GetItemId(int position)
    {
      return position;
    }

    //Transforma o layout em uma view que contem o layout 
    public override Android.Views.View GetView(int position, Android.Views.View convertView, ViewGroup parent)
    {
      //se o layoutInflater não estiver instanciado
      if (layoutInflater == null)
        layoutInflater = (LayoutInflater)activity.GetSystemService(Context.LayoutInflaterService);
      
      if (convertView == null)
        convertView = layoutInflater.Inflate(Resource.Layout.IconLayout, parent, false);

      //vinculacao dos controles
      ImageView icon = convertView.FindViewById<ImageView>(Resource.Id.imageView1);

      icon.SetImageResource(icon.ImageAlpha);
      return convertView;
    }
  }
}