﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeMegaWar {
    public partial class Default : System.Web.UI.Page {
        private Game game = new Game();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void buttonWar_Click(object sender, EventArgs e) {
            labelResults.Text = "";
            labelResults.Text += game.dealCards();
            labelResults.Text += game.playWar();
            labelResults.Text += game.printResults();
        }
    }
}