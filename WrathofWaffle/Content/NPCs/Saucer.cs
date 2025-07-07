using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace WrathofWaffle.NPCs
{
    public class Saucer : ModNPC
        
    {
        private int jumpTimer = 0;
        private int projectileTimer = 0;

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            NPC.width = 120;
            NPC.height = 100;
            NPC.damage = 40;
            NPC.defense = 10;
            NPC.lifeMax = 20090;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1; // Custom AI
            NPC.noGravity = false;
            NPC.noTileCollide = false;
            NPC.boss = true;
            NPC.value = Item.buyPrice(0, 2, 0, 0);
            NPC.lavaImmune = false;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            Music = MusicID.Boss1;
        }

        public override void AI()
        {
            Player target = Main.player[NPC.target];

            // Reacquire target if needed
            if (!target.active || target.dead)
            {
                NPC.TargetClosest(true);
                target = Main.player[NPC.target];
                if (!target.active || target.dead)
                {
                    NPC.velocity.Y += 0.1f; // fall
                    if (NPC.timeLeft > 10)
                        NPC.timeLeft = 10;
                    return;
                }
            }

            // Face the player
            NPC.spriteDirection = NPC.direction = (NPC.Center.X < target.Center.X) ? 1 : -1;

            // Teleport if too far
            if (Vector2.Distance(NPC.Center, target.Center) > 800f && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 teleportPos = target.position + new Vector2(Main.rand.Next(-200, 200), -100);
                NPC.position = teleportPos;
                NPC.velocity = Vector2.Zero;
                NPC.netUpdate = true;
            }

            // Jumping logic
            jumpTimer++;
            if (NPC.velocity.Y == 0f && jumpTimer > 60)
            {
                Vector2 jumpDirection = target.Center - NPC.Center;
                jumpDirection.Normalize();
                jumpDirection *= 6f;
                NPC.velocity = new Vector2(jumpDirection.X, -10f); // jump arc
                jumpTimer = 0;

                // Spawn Blue Slime
                if (Main.rand.NextBool(4) && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int type = NPCID.BlueSlime;
                    int index = NPC.NewNPC(NPC.GetSource_FromAI(), (int)NPC.Center.X, (int)NPC.Center.Y, type);
                    if (index < Main.maxNPCs)
                    {
                        Main.npc[index].velocity = new Vector2(Main.rand.NextFloat(-3f, 3f), -5f);
                    }
                }
            }

            // Projectile logic
            projectileTimer++;
            if (projectileTimer >= 120)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 shootDir = target.Center - NPC.Center;
                    shootDir.Normalize();
                    shootDir *= 8f;

                    int proj = Projectile.NewProjectile(
                     NPC.GetSource_FromAI(),
                     NPC.Center,
                     shootDir,
                    ProjectileID.SpikyBall,
                     15,
                     1f,
                     Main.myPlayer
 
                    );
                }

                projectileTimer = 1;
            }
        }
    }
}