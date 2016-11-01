using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DomainModels;
using DomainModels.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataService
{
    public class PostService : IPostService
    {
        public IList<Comment> GetComments()
        {
            throw new NotImplementedException();
        }

        public IList<Post> GetUsersPosts(int userId, int postTypeId)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int postId, int postTypeId) //Mangler return
        {
            using (var db = new SovaContext())
            {
                var conn = (MySqlConnection) db.Database.GetDbConnection();
                conn.Open();
                var cmd = new MySqlCommand("call getFavouritePosts(@jakhjo)", conn); //Prøver med den her da den har en parameter
                    cmd.Parameters.Add("@jakhjo", DbType.Int32).Value = postId; //Havde ikke nogen success at lave to parameter
                     //cmd.Parameters.Add("@jakhjo", DbType.Int32).Value = postTypeId;
               
                var result = new List<Post>();
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        result.Add(new Post
                        {
                            Id = rdr.GetInt16(0),
                            PostTypeId = rdr.GetInt16(1),
                            CreationDate = rdr.GetDateTime(2),
                            Score = rdr.GetInt16(3),
                            Body = rdr.GetString(4),
                            ClosedDate = rdr.GetDateTime(5),
                            Title = rdr.GetString(6)
                            //return db.Posts.FirstOrDefault(p => p.Id == postId && p.PostTypeId == postTypeId);
                        });

                    }
                    //return new Post();
                    //return result.FirstOrDefault(p => p.Id == postId && p.PostTypeId == postTypeId);
                    //// return db.Posts.FirstOrDefault(p => p.Id == postId && p.PostTypeId == postTypeId);
                }
            }
        }
    }
}
