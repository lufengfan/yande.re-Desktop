using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yandere.Data.Json
{
    internal sealed class post_json
    {
        public uint id { get; set; }
        public string tags { get; set; }
        public ulong created_at { get; set; }
        public ulong updated_at { get; set; }
        public uint? creator_id { get; set; }
        public uint? approver_id { get; set; }
        public string author { get; set; }
        public int change { get; set; }
        public string source { get; set; }
        public int score { get; set; }
        public string md5 { get; set; }
        public ulong file_size { get; set; }
        public string file_ext { get; set; }
        public string file_url { get; set; }
        public bool is_shown_in_index { get; set; }
        public string preview_url { get; set; }
        public int preview_width { get; set; }
        public int preview_height { get; set; }
        public int actual_preview_width { get; set; }
        public int actual_preview_height { get; set; }
        public string sample_url { get; set; }
        public int sample_width { get; set; }
        public int sample_height { get; set; }
        public ulong sample_file_size { get; set; }
        public string jpeg_url { get; set; }
        public int jpeg_width { get; set; }
        public int jpeg_height { get; set; }
        public ulong jpeg_file_size { get; set; }
        public string rating { get; set; }
        public bool is_rating_locked { get; set; }
        public bool has_children { get; set; }
        public uint? parent_id { get; set; }
        public string status { get; set; }
        public bool is_pending { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public bool is_held { get; set; }
        public string frames_pending_string { get; set; }
        public dynamic[] frames_pending { get; set; }
        public string frames_string { get; set; }
        public dynamic[] frames { get; set; }
        public bool is_note_locked { get; set; }
        public ulong last_noted_at { get; set; }
        public ulong last_commented_at { get; set; }
    }
}
