﻿namespace ourProject.ourModels.models
{
    public interface Worker
    {

        public int Id { get; set; }
        public string Name { get; set; }
       
        public int Password { get; set; }
        public string Role { get; set; }
    }
}
