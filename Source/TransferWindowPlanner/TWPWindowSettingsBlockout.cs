/*
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
using UnityEngine;
using KSPPluginFramework;

namespace TransferWindowPlanner
{
    /// <summary>
    /// This is just for a window to increase the opacoity of the settings window
    /// </summary>
    class TWPWindowSettingsBlockout:MonoBehaviourWindowPlus
    {
        internal TransferWindowPlanner mbTWP;

        internal override void DrawWindow(int id)
        {
            WindowRect = new Rect(mbTWP.windowSettings.WindowRect.x, mbTWP.windowSettings.WindowRect.y, mbTWP.windowSettings.WindowWidth, mbTWP.windowSettings.WindowHeight);
            GUILayout.Box("", new GUIStyle(), GUILayout.Width(100), GUILayout.Height(100));
        }
        internal override void Start()
        {
            WindowRect = new Rect(0, 0, mbTWP.windowSettings.WindowWidth, mbTWP.windowSettings.WindowHeight);
        }
    }
}
