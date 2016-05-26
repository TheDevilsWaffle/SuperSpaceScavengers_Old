<h1>Super Space Scavengers Game Design Document</h1>
<h2>Table of Contents</h2>
<ul>
  <li><a href="#DesignDocumentHistory" name="#">1. Design Document History</a></li>
  <li><a href="GameOverview" name="#">2. Game Overview</a>
    <ul>
      <li><a href="Concept" name="#" >2.1 &mdash; Concept</a></li>
      <li><a href="CoreFeatures" name="#" >2.2 &mdash; Core Features</a></li>
      <li><a href="GameFlowSummary" name="#" >2.3 &mdash; Game Flow Summary</a></li>
      <li><a href="Theme" name="#" >2.4 Theme</a></li>
      <li><a href="Genre" name="#" >2.5 &mdash; Genre</a></li>
    </ul>
  </li>
  <li><a href="#" name="#">3. Gameplay</a>
    <ul>
      <li><a href="#" name="#" >3.1 &mdash; Progression</a></li>
      <li><a href="#" name="#" >3.2 &mdash; Round Structure</a></li>
      <li><a href="#" name="#" >3.3 &mdash; Economy</a></li>
      <li><a href="#" name="#" >3.4 &mdash; Upgrade System</a></li>
      <li><a href="#" name="#" >3.5 &mdash; Environment Structure</a>
        <ul>
          <li><a href="#" name="#" >3.5.1 &mdash; Layout</a></li>
          <li><a href="#" name="#" >3.5.2 &mdash; Power Grid</a></li>
          <li><a href="#" name="#" >3.5.3 &mdash; Environment Decay</a></li>
          <li><a href="#" name="#" >3.5.4 &mdash; Enemy Placement</a></li>
          <li><a href="#" name="#" >3.5.5 &mdash; Loot Placement</a></li>
          <li><a href="#" name="#" >3.5.6 &mdash; Shop Placement</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >3.6 &mdash; Gameplay Influences</a>
        <ul>
          <li><a href="#" name="#" >3.6.1 &mdash; Game #1</a></li>
          <li><a href="#" name="#" >3.6.2 &mdash; Game #2</a></li>
          <li><a href="#" name="#" >3.6.3 &mdash; Game #3</a></li>
        </ul>
      </li>
    </ul>
  </li>
  <li><a href="#" name="#">4. Mechanics</a>
    <ul>
      <li><a href="#" name="#" >4.1 &mdash; Player Mechanics</a>
        <ul>
          <li><a href="#" name="#" >4.1.1 &mdash; Movement</a></li>
          <li><a href="#" name="#" >4.1.2 &mdash; Other Movement</a></li>
          <li><a href="#" name="#" >4.1.3 &mdash; Picking &amp; Dropping Objects</a></li>
          <li><a href="#" name="#" >4.1.4 &mdash; Contextual Interaction</a></li>
          <li><a href="#" name="#" >4.1.5 &mdash; Actions</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >4.2 &mdash; NPC Mechanics</a>
        <ul>
          <li><a href="#" name="#" >4.2.1 &mdash; NPC List</a></li>
          <li><a href="#" name="#" >4.2.2 &mdash; NPC States</a></li>
          <li><a href="#" name="#" >4.2.3 &mdash; NPC Actions</a></li>
          <li><a href="#" name="#" >4.2.4 &mdash; NPC Interactions</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >4.3 &mdash; Enemy Mechanics</a>
        <ul>
          <li><a href="#" name="#" >4.3.1 &mdash; Enemy List</a></li>
          <li><a href="#" name="#" >4.3.2 &mdash; Enemy States</a></li>
          <li><a href="#" name="#" >4.3.3 &mdash; Enemy Actions</a></li>
          <li><a href="#" name="#" >4.3.4 &mdash; Enemy Interactions</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >4.4 &mdash; Item Mechanics</a>
        <ul>
          <li><a href="#" name="#" >4.4.1 &mdash; Attribute Items</a></li>
          <li><a href="#" name="#" >4.4.2 &mdash; Combat Items</a></li>
          <li><a href="#" name="#" >4.4.3 &mdash; Non-Combat Items</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >4.5 &mdash;  Influences</a>
        <ul>
          <li><a href="#" name="#" >4.5.1 &mdash; Game #1</a></li>
          <li><a href="#" name="#" >4.5.2 &mdash; Game #2</a></li>
          <li><a href="#" name="#" >4.5.3 &mdash; Game #3</a></li>
        </ul>
      </li>
    </ul>
  </li>
  <li><a href="#" name="#">5. User Interface</a>
    <ul>
      <li><a href="#" name="#" >5.1 &mdash; UI Theme</a></li>
      <li><a href="#" name="#" >5.2 &mdash; Splash Screens</a></li>
      <li><a href="#" name="#" >5.3 &mdash; Main Menu</a></li>
      <li><a href="#" name="#" >5.4 &mdash; Pause Menu</a></li>
      <li><a href="#" name="#" >5.5 &mdash; In-Game UI</a>
        <ul>
          <li><a href="#" name="#" >5.5.1 &mdash; HUD</a></li>
          <li><a href="#" name="#" >5.5.2 &mdash; Action Specfic UI</a></li>
          <li><a href="#" name="#" >5.5.3 &mdash; Shop UI</a></li>
          <li><a href="#" name="#" >5.5.4 &mdash; End Round UI</a></li>
          <li><a href="#" name="#" >5.5.5 &mdash; End Game UI</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >5.6 &mdash; UI Influences</a>
        <ul>
          <li><a href="#" name="#" >5.6.1 &mdash; Game #1</a></li>
          <li><a href="#" name="#" >5.6.2 &mdash; Game #2</a></li>
          <li><a href="#" name="#" >5.6.3 &mdash; Game #3</a></li>
        </ul>
      </li>
    </ul>
  </li>
  <li><a href="#" name="#">6. Narrative</a>
    <ul>
      <li><a href="#" name="#" >6.1 &mdash; Theme Overview</a></li>
      <li><a href="#" name="#" >6.2 &mdash; Theme Mood</a></li>
      <li><a href="#" name="#" >6.3 &mdash; Back Story</a></li>
      <li><a href="#" name="#" >6.4 &mdash; Plot Elements</a>
      <li><a href="#" name="#" >6.5 &mdash; Cut Scenes/Cinematics</a></li>
      <li><a href="#" name="#" >6.6 &mdash; Game World</a>
        <ul>
          <li><a href="#" name="#" >6.6.1 &mdash; General Overview</a></li>
          <li><a href="#" name="#" >6.6.2 &mdash; Physical Characteristics</a></li>
          <li><a href="#" name="#" >6.6.3 &mdash; Example #1</a></li>
          <li><a href="#" name="#" >6.6.4 &mdash; Example #2</a></li>
          <li><a href="#" name="#" >6.6.5 &mdash; Example #3</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >6.7 &mdash; Players</a>
        <ul>
          <li><a href="#" name="#" >6.7.1 &mdash; Player #1 Personality</a></li>
          <li><a href="#" name="#" >6.7.2 &mdash; Player #1 Back Story</a></li>
          <li><a href="#" name="#" >6.7.3 &mdash; Player #2 Personality</a></li>
          <li><a href="#" name="#" >6.7.4 &mdash; Player #2 Back Story</a></li>
          <li><a href="#" name="#" >6.7.5 &mdash; Player #3 Personality</a></li>
          <li><a href="#" name="#" >6.7.6 &mdash; Player #3 Back Story</a></li>
          <li><a href="#" name="#" >6.7.7 &mdash; Player #4 Personality</a></li>
          <li><a href="#" name="#" >6.7.8 &mdash; Player #4 Back Story</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >6.8 &mdash; Narrative Influences</a>
        <ul>
          <li><a href="#" name="#" >6.8.1 &mdash; Game #1</a></li>
          <li><a href="#" name="#" >6.8.2 &mdash; Game #2</a></li>
          <li><a href="#" name="#" >6.8.3 &mdash; Game #3</a></li>
        </ul>
      </li>
    </ul>
  </li>
  <li><a href="#" name="#">7. Audio</a>
    <ul>
      <li><a href="#" name="#" >7.1 &mdash; General Overview</a></li>
      <li><a href="#" name="#" >7.2 &mdash; Mood</a></li>
      <li><a href="#" name="#" >7.3 &mdash; Music</a>
        <ul>
          <li><a href="#" name="#" >7.3.1 &mdash; Ambiet</a></li>
          <li><a href="#" name="#" >7.3.2 &mdash; Action</a></li>
          <li><a href="#" name="#" >7.3.3 &mdash; Victory</a></li>
          <li><a href="#" name="#" >7.3.4 &mdash; Defeat</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >7.4 &mdash; SFX</a>
        <ul>
          <li><a href="#" name="#" >7.4.1 &mdash; Menu SFX List</a></li>
          <li><a href="#" name="#" >7.4.2 &mdash; Player SFX List</a></li>
          <li><a href="#" name="#" >7.4.3 &mdash; NPC SFX List</a></li>
          <li><a href="#" name="#" >7.4.4 &mdash; Enemy SFX List</a></li>
          <li><a href="#" name="#" >7.4.5 &mdash; Environment SFX List</a></li>
          <li><a href="#" name="#" >7.4.6 &mdash; Item SFX List</a></li>
          <li><a href="#" name="#" >7.4.7 &mdash; Combat SFX List</a></li>
          <li><a href="#" name="#" >7.4.8 &mdash; UI SFX List</a></li>
        </ul>
      </li>
      <li><a href="#" name="#" >7.5 &mdash; Audio Influences</a>
        <ul>
          <li><a href="#" name="#" >7.5.1 &mdash; Game #1</a></li>
          <li><a href="#" name="#" >7.5.2 &mdash; Game #2</a></li>
          <li><a href="#" name="#" >7.5.3 &mdash; Game #3</a></li>
        </ul>
      </li>
    </ul>
  </li>
</ul>

<!--1. DESIGN DOCUMENT HISTORY-->
<h2 id="DesignDocumentHistory">1. Design Document History</h2>
<ul>
	<li>
		<h3>Version 0.0.1</h3>
		<p>Initial creation of the Design Document, mostly markdown structure. Some parts from section 1 and 2 added.</p>
	</li>
</ul>

<!--2. GAME OVERVIEW-->
<h2 id="GameOverview">2. Game Overview</h2>
<ul>
	<li>
		<h3 id="Concept">2.1 Concept</h3>
		<p><em>Super Space Scavengers</em> is a couch multiplayer computer game where players fight to strip an abandoned space ship of its most valuable parts before the ship becomes completely unstable and explodes!</p>
	</li>
	<li>
		<h3 id="CoreFeatures">2.2 Core Features</h3>
		<p><em>Super Space Scavengers</em> has the following three core features:
			<ul>
				<li>
					<strong>Simple Controls</strong>
					<p><em>Super Space Scavengers</em> is a game that is easy to pick up and start playing without an overly complex control scheme.</p>
				</li>
				<li>
					<strong>Procedurally Generated Space Ships</strong>
					<p>Every round features a differentely generated abandoned space ship to explore, complete with a different language and iconography so each ship feels truly alien to the player.</p>
				</li>
				<li>
					<strong>Fast and Frantic Multiplayer</strong>
					<p>Each game of <em>Super Space Scavengers</em> only takes about 10 &ndash; 15 minutes and is rife with action, explosions, power failures, and many, many player deaths.</p>
				</li>
			</ul>
		</p>
	</li>
	<li>
		<h3 id="GameFlowSummary">2.3 Game Flow Summary</h3>
		<p><em>Super Space Scavengers</em>  follows a game flow not very different from an arcade game experience:
		<code>
			[Title Screen]=>[Main Menu]=>[Player Select/Confirmation]=>[Gameplay]=>[Round Results Menu]=>[End Game]
		</code>
		</p>
	</li>
	<li>
		<h3 id="Theme">2.4 Theme</h3>
		<p><em>Super Space Scavengers</em> is set in space. As such the game has a very futuristic theme, common with most space games. Like the movie <em>Star Wars: A New Hope</em>, the setting of <em>Super Space Scavengers</em> is a very used version of space (think the Jawas on Tatooine or anywhere in Mos Eisley). The world has advanced and futuristic technology, but it's not new and pristine.</p>
	</li>
	<li>
		<h3 id="Genre">2.5 Genre</h3>
		<p><em>Super Space Scavengers</em> is designed to be a arcade-action couch multiplayer computer game experienced by up to 4 players without splitscreen.</p>
	</li>
</ul>