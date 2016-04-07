namespace Blobs.Models
{
    using System;
    using Blobs.Models.Interfaces;
    using System.Text;

    public class Blob : IBlob
    {
        private bool isBehaviorTriggered;
        private int turnSinceBehaviorTrggeredCounter;

        public Blob(string name, int health, int damage, IBehavior behavior, IAttack attackType)
        {
            this.isBehaviorTriggered = false;
            this.turnSinceBehaviorTrggeredCounter = 0;
            this.Name = name;
            this.InitialHealth = health;
            this.Health = health;
            this.InitialDamage = damage;
            this.Damage = damage;
            this.Behavior = behavior;
            this.AttackType = attackType;
        }

        public string Name { get; private set; }

        public int InitialHealth { get; set; }

        public int Health { get; private set; }

        public int InitialDamage { get; private set; }

        public int Damage { get; private set; }

        public IBehavior Behavior { get; private set; }

        public IAttack AttackType { get; private set; }

        public bool IsKilled
        {
            get { return this.Health < 1; }
        }

        public void Attack(IBlob target)
        {
            //this.Damage = this.InitialDamage;
            target.DropHealth(this.Damage * this.AttackType.DamageModifier);
            
            if (this.AttackType.HealthModifier == 1)
            {
                this.DropHealth(0);
            }
            else
            {
                this.DropHealth(this.Health / this.AttackType.HealthModifier);
            }
        }

        private void TriggerBehavior()
        {
            if (isBehaviorTriggered)
            {
                throw new InvalidOperationException("Blob behavior can be triggered only once.");
            }

            this.Health += this.Behavior.HealthModifier;
            this.Damage = this.Damage * this.Behavior.DamageModifier;
            this.isBehaviorTriggered = true;
        }

        public void DropHealth(int healthLoss)
        {
            this.Health = this.Health - healthLoss;
            
            if (this.Health < 0)
            {
                this.Health = 0;
            }
            if (this.Health <= this.InitialHealth / 2 && !this.isBehaviorTriggered)
            {
                this.TriggerBehavior();
            }
            
        }

        private void DropDamage(int damageLoss)
        {
            int resultingDamage = this.Damage - damageLoss;
            if (resultingDamage < this.InitialDamage)
            {
                this.Damage = this.InitialDamage;
            }
            else
            {
                this.Damage = resultingDamage;
            }
        }

        public void Update()
        {
            if (this.isBehaviorTriggered)
            {
                if (this.turnSinceBehaviorTrggeredCounter > 0)
                {
                    this.DropDamage(this.Behavior.DamageLossPerTurn);
                    this.DropHealth(this.Behavior.HealthLossPerTurn);
                }
                this.turnSinceBehaviorTrggeredCounter++;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            output.Append($"Blob {this.Name}");
            if (this.IsKilled)
            {
                output.Append(" KILLED");
            }
            else
            {
                output.Append($": {this.Health} HP, {this.Damage} Damage");
            }
            
            return output.ToString();
        }

        
    }
}
