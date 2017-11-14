﻿using Newtonsoft.Json.Linq;

namespace Take.Blip.Builder
{
    /// <summary>
    /// Defines an action to be executed when a state is activated.
    /// </summary>
    public class Action
    {
        /// <summary>
        /// The unique identifier of the action.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The action execution order, relative to the others in the same state. Optional.
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// The action type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The action settings for the specified type.
        /// </summary>
        public JObject Settings { get; set; }
    }
}
