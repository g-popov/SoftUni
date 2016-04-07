namespace Blobs.Core
{
    using System;
    using System.Collections.Generic;
    using Blobs.Interfaces;
    using System.Linq;

    public class BlobsDispatcher : IDispatcher
    {
        private IData data;
        private IBlobFactory blobFactory;
        private IBehaviorFactory behaviorFactory;
        private IAttackFactory attackFactory;
        private IWriter writer;

        public BlobsDispatcher(IData data, IBlobFactory blobFactory, IBehaviorFactory behaviorFactory, IAttackFactory attackFactory, IWriter writer)
        {
            this.data = data;
            this.blobFactory = blobFactory;
            this.behaviorFactory = behaviorFactory;
            this.attackFactory = attackFactory;
            this.writer = writer;
        }

        public void DispatchCommand(ICommand command)
        {
            switch (command.Name)
            {
                case "create":
                    this.ExecuteCreateCommand(command.Parameters);
                    break;
                case "attack":
                    this.ExecuteAttackCommand(command.Parameters);
                    break;
                case "pass":
                    break;
                case "status":
                    this.ExecuteStatusCommand();
                    break;
                default:
                    throw new ArgumentException("Unknown command.");
            }
        }

        private void ExecuteStatusCommand()
        {
            foreach (var blob in data.Blobs)
            {
                writer.WriteLine(blob.ToString());
            }
        }

        private void ExecuteAttackCommand(IList<string> parameters)
        {
            var attackerName = parameters[0];
            var targetName = parameters[1];
            var attacker = this.data.Blobs.Where(b => b.Name == attackerName).First();
            var target = this.data.Blobs.Where(b => b.Name == targetName).First();

            attacker.Attack(target);
        }

        private void ExecuteCreateCommand(IList<string> parameters)
        {
            string blobName = parameters[0];
            int blobHealth = int.Parse(parameters[1]);
            int blobDamage = int.Parse(parameters[2]);
            string behaviorType = parameters[3];
            string attackType = parameters[4];

            var behavior = this.behaviorFactory.CreateBehavior(behaviorType);
            var attack = this.attackFactory.CreateAttack(attackType);
            var blob = this.blobFactory.CreateBlob(blobName, blobHealth, blobDamage, behavior, attack);

            this.data.AddBlob(blob);

        }
    }
}
