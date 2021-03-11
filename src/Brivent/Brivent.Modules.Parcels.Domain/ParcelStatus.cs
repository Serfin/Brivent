namespace Brivent.Modules.Parcels.Domain
{
    public enum ParcelStatus
    {
        DuringPreparation,   // W trakcie przygotowania
        ReceivedFromSender,  // Odebrana od nadawcy 
        ReceivedInBranch,    // Odebrana w oddziale
        SentFromBranch,      // Wysłana z oddziału
        DeliveredToDelivery, // Wydana do doręczenia
        ReadyForReception,   // Gotowa do odbioru
        Received             // Odebrana
    }
}