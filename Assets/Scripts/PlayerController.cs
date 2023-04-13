using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    private Vector2 currentPos;

    private Animator animator;

    public LayerMask solidObjectsLayer;
    public LayerMask interactablesLayer;

    public GameObject buy_bread_from_baker;
    public BuyBreadFromBaker_Event buy_bread_event;

    public GameObject fish_from_the_docks;
    public FishFromTheDocksEvent fish_from_dock;

    public GameObject get_haircut_from_barber;
    public GetHaircutEvent get_haircut_event;

    public GameObject read_at_library;
    public ReadAtLibraryEvent read_at_library_event;

    public GameObject make_investment_at_bank;
    public MakeInvestmentAtBankEvent make_investment_at_bank_event;

    public GameObject rob_the_bank;
    public RobTheBankEvent rob_the_bank_event;

    public GameObject noble_garden_party;
    public VisitNobleGardenPartyEvent noble_garden_party_event;

    public GameObject visit_bathhouse;
    public VisitBathhouseEvent visit_bathhouse_event;

    public GameObject give_beggar;
    public GiveBeggarDonationEvent give_beggar_event;

    public GameObject illegal_gambling;
    public IllegalGamblingEvent illegal_gambling_event;

    public GameObject ale_at_tavern;
    public GetAleAtTavernEvent ale_at_tavern_event;

    public GameObject unload_ship_goods;
    public UnloadingShipGoodsEvent unload_ship_goods_event;

    public GameObject steal_ship_supplies;
    public StealShipSuppliesEvent steal_ship_supplies_event;

    public GameObject visit_fortune_teller;
    public VisitFortuneTellerEvent visit_fortune_teller_event;

    public GameObject buy_healing_mixture;
    public BuyHealingMixtureEvent buy_healing_mixture_event;

    public GameObject buy_equipment_blacksmith;
    public BuyEquipmentBlacksmithEvent buy_equipment_blacksmith_event;

    public GameObject medidate_at_shrine;
    public MedidateAtShrineEvent medidate_at_shrine_event;

    public GameObject hunt_in_forest;
    public HuntInForestEvent hunt_in_forest_event;
    
    public GameObject help_farmer_collect_harvest;
    public HelpFarmerCollectHarvestEvent help_farmer_collect_harvest_event;

    public GameObject acedemic_research;
    public AcademicResearchEvent acedemic_research_event;

    public GameObject trade_spices;
    public TradeSpicesEvent trade_spices_event;

    public GameObject break_in_noble_house;
    public BreakInNobleHouseEvent break_in_noble_house_event;

    public GameObject donate_to_faith;
    public DonateToFaithEvent donate_to_faith_event;

    public GameObject mine_for_ore;
    public MineForOreEvent mine_for_ore_event;

    public GameObject sabotage_guard_armory;
    public SabotageGuardArmoryEvent sabotage_guard_armory_event;

    public GameObject perform_ritual;
    public PerformRitualEvent perform_ritual_event;

    private BoxCollider2D buy_bread_from_baker_collider;
    private BoxCollider2D fish_from_the_docks_collider;
    private BoxCollider2D get_haircut_from_barber_collider;
    private BoxCollider2D read_at_library_collider;
    private BoxCollider2D make_investment_at_bank_collider;
    private BoxCollider2D rob_the_bank_collider;
    private BoxCollider2D noble_garden_party_collider;
    private BoxCollider2D visit_bathhouse_collider;
    private BoxCollider2D give_beggar_collider;
    private BoxCollider2D illegal_gambling_collider;
    private BoxCollider2D ale_at_tavern_collider;
    private BoxCollider2D unload_ship_goods_collider;
    private BoxCollider2D steal_ship_supplies_collider;
    private BoxCollider2D visit_fortune_teller_collider;
    private BoxCollider2D buy_healing_mixture_collider;
    private BoxCollider2D buy_equipment_blacksmith_collider;
    private BoxCollider2D meditate_at_shrine_collider;
    private BoxCollider2D hunt_in_forest_collider;
    private BoxCollider2D help_farmer_collect_harvest_collider;
    private BoxCollider2D acedemic_research_collider;
    private BoxCollider2D trade_spices_collider;
    private BoxCollider2D break_in_noble_house_collider;
    private BoxCollider2D donate_to_faith_collider;
    private BoxCollider2D mine_for_ore_collider;
    private BoxCollider2D sabotage_guard_armory_collider;
    private BoxCollider2D perform_ritual_collider;



    private void Awake()
    {
        animator = GetComponent<Animator>();
        buy_bread_from_baker_collider = buy_bread_from_baker.GetComponent<BoxCollider2D>();
        fish_from_the_docks_collider = fish_from_the_docks.GetComponent<BoxCollider2D>();
        get_haircut_from_barber_collider = get_haircut_from_barber.GetComponent<BoxCollider2D>();
        read_at_library_collider = read_at_library.GetComponent<BoxCollider2D>();
        make_investment_at_bank_collider = make_investment_at_bank.GetComponent<BoxCollider2D>();
        rob_the_bank_collider = rob_the_bank.GetComponent<BoxCollider2D>();
        noble_garden_party_collider = noble_garden_party.GetComponent<BoxCollider2D>();
        visit_bathhouse_collider = visit_bathhouse.GetComponent<BoxCollider2D>();
        give_beggar_collider = give_beggar.GetComponent<BoxCollider2D>();
        illegal_gambling_collider = illegal_gambling.GetComponent<BoxCollider2D>();
        ale_at_tavern_collider = ale_at_tavern.GetComponent<BoxCollider2D>();
        unload_ship_goods_collider = unload_ship_goods.GetComponent<BoxCollider2D>();
        steal_ship_supplies_collider = steal_ship_supplies.GetComponent<BoxCollider2D>();
        visit_fortune_teller_collider = visit_fortune_teller.GetComponent<BoxCollider2D>();
        buy_healing_mixture_collider = buy_healing_mixture.GetComponent<BoxCollider2D>();
        buy_equipment_blacksmith_collider = buy_equipment_blacksmith.GetComponent<BoxCollider2D>();
        meditate_at_shrine_collider = medidate_at_shrine.GetComponent<BoxCollider2D>();
        hunt_in_forest_collider = hunt_in_forest.GetComponent<BoxCollider2D>();
        help_farmer_collect_harvest_collider = help_farmer_collect_harvest.GetComponent<BoxCollider2D>();
        acedemic_research_collider = acedemic_research.GetComponent<BoxCollider2D>();
        trade_spices_collider = trade_spices.GetComponent<BoxCollider2D>();
        break_in_noble_house_collider = break_in_noble_house.GetComponent<BoxCollider2D>();
        donate_to_faith_collider = donate_to_faith.GetComponent<BoxCollider2D>();
        mine_for_ore_collider = mine_for_ore.GetComponent<BoxCollider2D>();
        sabotage_guard_armory_collider = sabotage_guard_armory.GetComponent<BoxCollider2D>();
        perform_ritual_collider = perform_ritual.GetComponent<BoxCollider2D>();

        currentPos = new Vector2(transform.position.x, transform.position.y);
    }




    // Update is called once per frame
    public void HandleUpdate()
    {
        // checking if player is inside event area
        eventCollisionChecker();


        if (!isMoving)
        {
            // gets input from wasd (0 no movement, 1 up/right, -1 down/left)
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");


            // removes diagonal moving
            if (input.x != 0) input.y = 0; 

            if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(isWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }

            }
        } 

        animator.SetBool("isMoving", isMoving);

    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }
    
    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.05f, solidObjectsLayer) != null)
        {
            return false;
        }
        return true;
    }


    private void insideEventZone(BoxCollider2D eventCollider)
    {
        // remember to set the z-value of the event zones box colliders to 0
        if (eventCollider.bounds.Contains(transform.position))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Starting event: " + eventCollider.name);

                var curentPos = transform.position;

                var collider = Physics2D.OverlapCircle(curentPos, 0.2f, interactablesLayer);
                if (collider != null)
                {
                    var eventTag = collider.tag;
                    var outcomeString = runSpecificEvent(eventTag);

                    collider.GetComponent<Interactable>()?.Interact(outcomeString);
                }
            }
        }
    }

    private void eventCollisionChecker()
    {
        insideEventZone(buy_bread_from_baker_collider);
        insideEventZone(fish_from_the_docks_collider);
        insideEventZone(get_haircut_from_barber_collider);
        insideEventZone(read_at_library_collider);
        insideEventZone(make_investment_at_bank_collider);
        insideEventZone(rob_the_bank_collider);
        insideEventZone(noble_garden_party_collider);
        insideEventZone(visit_bathhouse_collider);
        insideEventZone(give_beggar_collider);
        insideEventZone(illegal_gambling_collider);
        insideEventZone(ale_at_tavern_collider);
        insideEventZone(unload_ship_goods_collider);
        insideEventZone(steal_ship_supplies_collider);
        insideEventZone(visit_fortune_teller_collider);
        insideEventZone(buy_healing_mixture_collider);
        insideEventZone(buy_equipment_blacksmith_collider);
        insideEventZone(meditate_at_shrine_collider);
        insideEventZone(hunt_in_forest_collider);
        insideEventZone(help_farmer_collect_harvest_collider);
        insideEventZone(acedemic_research_collider);
        insideEventZone(trade_spices_collider);
        insideEventZone(break_in_noble_house_collider);
        insideEventZone(donate_to_faith_collider);
        insideEventZone(mine_for_ore_collider);
        insideEventZone(sabotage_guard_armory_collider);
        insideEventZone(perform_ritual_collider);


    }

    private string runSpecificEvent (string input)
    {
        return (input == "bread") ? buy_bread_event.Run() :
               (input == "fish") ? fish_from_dock.Run() :
               (input == "haircut") ? get_haircut_event.Run() :
               (input == "library") ? read_at_library_event.Run() :
               (input == "investment") ? make_investment_at_bank_event.Run() :
               (input == "bank") ? rob_the_bank_event.Run() :
               (input == "garden") ? noble_garden_party_event.Run() :
               (input == "bath") ? visit_bathhouse_event.Run() :
               (input == "beggar") ? give_beggar_event.Run() :
               (input == "gambling") ? illegal_gambling_event.Run() :
               (input == "ale") ? ale_at_tavern_event.Run() :
               (input == "unload") ? unload_ship_goods_event.Run() :
               (input == "steal") ? steal_ship_supplies_event.Run() :
               (input == "fortune") ? visit_fortune_teller_event.Run() :
               (input == "healing") ? buy_healing_mixture_event.Run() :
               (input == "blacksmith") ? buy_equipment_blacksmith_event.Run() :
               (input == "meditate") ? medidate_at_shrine_event.Run() :
               (input == "hunt") ? hunt_in_forest_event.Run() :
               (input == "harvest") ? help_farmer_collect_harvest_event.Run() :
               (input == "acedemic") ? acedemic_research_event.Run() :
               (input == "spices") ? trade_spices_event.Run() :
               (input == "breakin") ? break_in_noble_house_event.Run() :
               (input == "faith") ? donate_to_faith_event.Run() :
               (input == "mine") ? mine_for_ore_event.Run() :
               (input == "sabotage") ? sabotage_guard_armory_event.Run() :
               (input == "ritual") ? perform_ritual_event.Run() :
               null;

        return "404";
    }

}
