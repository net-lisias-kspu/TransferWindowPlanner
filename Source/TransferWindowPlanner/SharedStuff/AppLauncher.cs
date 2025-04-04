﻿/*
	This file is part of Transfer Window Planner /L Unleashed
		© 2023 Lisias T : http://lisias.net <support@lisias.net>
		© 2014-2022 TriggerAu

	Transfer Window Planner is double licensed, as follows:
		* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Transfer Window Planner /L Unleashed is distributed in the hope that it will be
	useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Transfer Window Planner /L Unleashed. If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Transfer Window Planner /L Unleashed. If not, see <https://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KSP;
using KSP.UI.Screens;
using UnityEngine;
using KSPPluginFramework;

namespace TransferWindowPlanner
{
    public partial class TransferWindowPlanner
    {
        /// <summary>
        /// Sets up the App Button - no longer called by the event as that only happens on StartMenu->SpaceCenter now
        /// </summary>
        void OnGUIAppLauncherReady()
        {
            MonoBehaviourExtended.LogFormatted_DebugOnly("AppLauncherReady");
            if (settings.ButtonStyleChosen == Settings.ButtonStyleEnum.Launcher )
            {
                btnAppLauncher = InitAppLauncherButton();
            }
        }

        void OnGameSceneLoadRequestedForAppLauncher(GameScenes SceneToLoad)
        {
            LogFormatted_DebugOnly("GameSceneLoadRequest");
            DestroyAppLauncherButton();
        }
        internal ApplicationLauncherButton btnAppLauncher = null;

        internal ApplicationLauncherButton InitAppLauncherButton()
        {
            ApplicationLauncherButton retButton = null;

            //ApplicationLauncherButton[] lstButtons = TransferWindowPlanner.FindObjectsOfType<ApplicationLauncherButton>();
            //LogFormatted("AppLauncher: Creating Button-BEFORE", lstButtons.Length);
            try
            {
                retButton = ApplicationLauncher.Instance.AddModApplication(
                    onAppLaunchToggleOn, onAppLaunchToggleOff,
                    onAppLaunchHoverOn, onAppLaunchHoverOff,
                    null, null,
                    ApplicationLauncher.AppScenes.ALWAYS,
                    (Texture)Resources.texAppLaunchIcon);

                //AppLauncherButtonMutuallyExclusive(settings.AppLauncherMutuallyExclusive);

                //appButton = ApplicationLauncher.Instance.AddApplication(
                //    onAppLaunchToggleOn, onAppLaunchToggleOff,
                //    onAppLaunchHoverOn, onAppLaunchHoverOff,
                //    null, null,
                //    (Texture)Resources.texAppLaunchIcon);
                //appButton.VisibleInScenes = ApplicationLauncher.AppScenes.FLIGHT;

            }
            catch (Exception ex)
            {
                MonoBehaviourExtended.LogFormatted("AppLauncher: Failed to set up App Launcher Button\r\n{0}", ex.Message);
                retButton = null;
            }
            //lstButtons = TransferWindowPlanner.FindObjectsOfType<ApplicationLauncherButton>();
            //LogFormatted("AppLauncher: Creating Button-AFTER", lstButtons.Length);

            return retButton;
        }


        internal void DestroyAppLauncherButton()
        {
            //LogFormatted("AppLauncher: Destroying Button-BEFORE NULL CHECK");
            if (btnAppLauncher != null)
            {
                ApplicationLauncherButton[] lstButtons = TransferWindowPlanner.FindObjectsOfType<ApplicationLauncherButton>();
                //LogFormatted("AppLauncher: Destroying Button-Button Count:{0}", lstButtons.Length);
                ApplicationLauncher.Instance.RemoveModApplication(btnAppLauncher);
                btnAppLauncher = null;
            }
            //LogFormatted("AppLauncher: Destroying Button-AFTER NULL CHECK");
        }

        void onAppLaunchToggleOn() {
            MonoBehaviourExtended.LogFormatted_DebugOnly("TOn");

            windowMain.Visible = true;
        }
        void onAppLaunchToggleOff() {
            MonoBehaviourExtended.LogFormatted_DebugOnly("TOff");

            windowMain.Visible = false;
        }
        void onAppLaunchHoverOn() {
            MonoBehaviourExtended.LogFormatted_DebugOnly("HovOn");
            //MouseOverAppLauncherBtn = true;
        }
        void onAppLaunchHoverOff() {
            MonoBehaviourExtended.LogFormatted_DebugOnly("HovOff");
            //MouseOverAppLauncherBtn = false; 
        }

        //Boolean MouseOverAppLauncherBtn = false;
    }
}
