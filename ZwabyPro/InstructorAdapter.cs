using System;
using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ZwabyPro
{
    public class InstructorAdapter : BaseAdapter<Instructor>, ISectionIndexer
    {
        Java.Lang.Object[] sectionHeaders = SectionIndexerBuilder.BuildSectionHeaders(InstructorData.Instructors);
        Dictionary<int, int> positionForSectionMap = SectionIndexerBuilder.BuildPositionForSectionMap(InstructorData.Instructors);
        Dictionary<int, int> sectionForPositionMap = SectionIndexerBuilder.BuildSectionForPositionMap(InstructorData.Instructors);

        Activity context;
        List<Instructor> instructors;

        public InstructorAdapter(Activity context, List<Instructor> instructors)
        {
            this.context = context;
            this.instructors = instructors;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (convertView == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.InstructorRow, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var specialty = view.FindViewById<TextView>(Resource.Id.specialtyTextView);

                var viewHolder = new ViewHolder
                {
                    Photo = photo,
                    Name = name,
                    Specialty = specialty
                };

                view.Tag = viewHolder;
            }

            var holder = (ViewHolder)view.Tag;

            holder.Photo.SetImageDrawable(ImageAssetManager.Get(context, instructors[position].ImageUrl));
            holder.Name.Text = instructors[position].Name;
            holder.Specialty.Text = instructors[position].Specialty;

            return view;
        }

        public override Instructor this[int position]
        {
            get
            {
                return instructors[position];
            }
        }

        public override int Count
        {
            get
            {
                return instructors.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public int GetPositionForSection(int sectionIndex)
        {
            return positionForSectionMap[sectionIndex];
        }

        public int GetSectionForPosition(int position)
        {
            return sectionForPositionMap[position];
        }

        public Java.Lang.Object[] GetSections()
        {
            return sectionHeaders;
        }
    }
}
