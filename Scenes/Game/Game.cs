using CircleGame.Core.Systems.Mana;
using CircleGame.Core.Systems.PassiveSpells;
using CircleGame.Core.Systems.Stats;
using CircleGame.Core.Systems.Tower;
using Godot;

namespace CircleGame.Scenes.Game;

public partial class Game : Node2D
{
	private Label _mana;
	private Button _addManaButton;
	private Button _upgradeManaRegenButton;
	private Label _manaRegenLabel;
	private Label _manaRegenLevelLabel;

	private Label _floorLabel;
	private Label _hpLabel;
	private Button _dealDamageButton;

	public override void _Ready()
	{
		_mana = GetNode<Label>("%Mana");
		_addManaButton = GetNode<Button>("%AddManaButton");
		_addManaButton.ButtonDown += OnAddManaButtonPressed;
		_addManaButton.ButtonUp += OnAddManaButtonPressed;
		_upgradeManaRegenButton = GetNode<Button>("%UpgradeManaRegenButton");
		_upgradeManaRegenButton.Pressed += OnUpgradeManaRegenButtonPressed;
		_manaRegenLabel = GetNode<Label>("%ManaRegenLabel");
		_manaRegenLevelLabel = GetNode<Label>("%ManaRegenLevel");

		_floorLabel = GetNode<Label>("%FloorLabel");
		_hpLabel = GetNode<Label>("%HpLabel");
		_dealDamageButton = GetNode<Button>("%DealDamageButton");
		_dealDamageButton.ButtonDown += OnDealDamageButtonPressed;
		_dealDamageButton.ButtonUp += OnDealDamageButtonPressed;
	}

	public override void _Process(double delta)
	{
		_mana.Text = ManaManager.Instance.Mana.ToString();
		_manaRegenLabel.Text = $"Mana Regen: {StatManager.Instance.GetFinal(BaseStat.ManaRegen)}";
		_manaRegenLevelLabel.Text = $"Mana Regen Level: {PassiveSpellManager.Instance.PassiveSpells[PassiveSpellType.ManaRegen].Level}";

		_floorLabel.Text = $"Floor: {TowerManager.Instance.CurrentFloor}";
		_hpLabel.Text = $"HP: {TowerManager.Instance.CurrentHp}/{TowerManager.Instance.MaxHp}";
	}

	private void OnAddManaButtonPressed()
	{
		ManaManager.Instance.IsCultivating = !ManaManager.Instance.IsCultivating;
	}

	private void OnUpgradeManaRegenButtonPressed()
	{
		PassiveSpellManager.Instance.UpgradeSpell(PassiveSpellType.ManaRegen);
	}

	private void OnDealDamageButtonPressed()
	{
		TowerManager.Instance.IsAttacking = !TowerManager.Instance.IsAttacking;
	}
}
