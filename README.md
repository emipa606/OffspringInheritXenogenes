# [Offspring Inherit Xenogenes (Continued)](https://steamcommunity.com/sharedfiles/filedetails/?id=3266000468)

![Image](https://i.imgur.com/buuPQel.png)

Update of Seas mod https://steamcommunity.com/sharedfiles/filedetails/?id=2879792769

![Image](https://i.imgur.com/pufA0kM.png)
	
![Image](https://i.imgur.com/Z4GOv8H.png)

In vanilla, endogenes ('natural genes') may be inherited by offspring while xenogenes ('artificial genes') may not. This mod changes it so that xenogenes can be inherited by offspring, following the same logic as vanilla - 50% chance if one parent has the xenogene, 100% chance if both parents have it.

Furthermore, this mod changes the likelihood of inheriting archite genes. In vanilla, inheriting archite genes is impossible. Archite gene inheritance probability is calculated using this formula, one per parent additively: 0.5 * (1.0 / (gene_complexity + 1.0)). That means that one parent with the Ageless gene, which has a complexity of 3, would have a 12.5% chance to pass it on - if both parents have it, there's a 25% chance to pass it on.

Plus, all of these values are configurable! So if you want xenogens to be passed on, but at a lower chance, or you want to guarantee or entirely disable archite inheritance, or any other tweaks, just check the mod options!

One last note about how vanilla gene inheritance works, which this mod has not changed: when a pawn is generated, it is assigned a maximum metabolism based on the following logic: 70% chance for 1, 20% chance for 2, 10% chance for 3. A pawn with metabolism 1 will not be able to inherit any genes that would push their total metabolism outside of the range { -1, 1 }. If some of your xenogenes aren't being inherited sometimes, it's because of this mechanic. My other mod removes this system: https://steamcommunity.com/sharedfiles/filedetails/?id=3225695697

Safe to be added to, and removed from, existing saves. Genes are determined by the game at the point of conception, so adding this mod during an existing pregnancy won't change the baby's genes.

Check out my other gene mods!

Hermaphrodite Gene: https://steamcommunity.com/sharedfiles/filedetails/?id=2879035868
Male- and Female- Only Genes: https://steamcommunity.com/sharedfiles/filedetails/?id=2879538186
Femboy Gene: https://steamcommunity.com/sharedfiles/filedetails/?id=2881009626

![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using [HugsLib](https://steamcommunity.com/workshop/filedetails/?id=818773962) or the standalone [Uploader](https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404) and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use [RimSort](https://github.com/RimSort/RimSort/releases/latest) to sort your mods

 

[![Image](https://img.shields.io/github/v/release/emipa606/OffspringInheritXenogenes?label=latest%20version&style=plastic&color=9f1111&labelColor=black)](https://steamcommunity.com/sharedfiles/filedetails/changelog/3266000468) | tags:  inherited genes
