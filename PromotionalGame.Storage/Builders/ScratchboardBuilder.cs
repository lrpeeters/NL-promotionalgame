using PromotionalGame.Storage.Models;

namespace PromotionalGame.Storage.Builders;

internal class ScratchboardBuilder : IScratchboardBuilder
{
    private int? _numberOfFields;

    private readonly List<int> _grandPrizeFields = [];

    private readonly List<int> _consolationPrizeFields = [];

    public IScratchboardBuilder WithFields(int numberOfFields)
    {
        _numberOfFields = numberOfFields;
        return this;
    }

    public IScratchboardBuilder WithGrandPrize(int numberOfGrandPrizes)
    {
        CalculatePrizeFields(numberOfGrandPrizes, _grandPrizeFields);
        return this;
    }

    public IScratchboardBuilder WithConsolationPrize(int numberOfConsolationPrizes)
    {
        CalculatePrizeFields(numberOfConsolationPrizes, _consolationPrizeFields);
        return this;
    }

    public Scratchboard Build()
    {
        var fields = new List<ScratchableField>();

        for (int i = 0; i < _numberOfFields; i++)
        {
            var field = new ScratchableField
            {
                Id = Guid.NewGuid(),
                Prize = GetFieldPrize(i)
            };

            fields.Add(field);
        }

        var board = new Scratchboard
        {
            Fields = fields
        };
        return board;
    }

    private ScratchPrizes GetFieldPrize(int fieldNumber)
    {
        if (fieldNumber >= _numberOfFields)
        {
            throw new ArgumentOutOfRangeException(nameof(fieldNumber));
        }

        if (_grandPrizeFields.Contains(fieldNumber))
        {
            return ScratchPrizes.GrandPrize;
        }

        if (_consolationPrizeFields.Contains(fieldNumber))
        {
            return ScratchPrizes.ConsolationPrize;
        }

        return ScratchPrizes.Bummer;
    }

    private void CalculatePrizeFields(int numberOfPrizes, List<int> prizedFields)
    {
        if (_numberOfFields is null)
        {
            throw new InvalidOperationException("Set the number of fields first.");
        }

        if (numberOfPrizes > _numberOfFields)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfPrizes));
        }

        for (int i = 0; i < numberOfPrizes; i++)
        {
            var fieldAlreadyUsed = true;
            var prizeFieldNumber = 0;

            while (fieldAlreadyUsed)
            {
                var randomizer = new Random();
                prizeFieldNumber = randomizer.Next(_numberOfFields.Value);

                fieldAlreadyUsed =
                    _grandPrizeFields.Contains(prizeFieldNumber) ||
                    _consolationPrizeFields.Contains(prizeFieldNumber);
            }

            prizedFields.Add(prizeFieldNumber);
        }
    }
}
